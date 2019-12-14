using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver.Core.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IConnection = RabbitMQ.Client.IConnection;

namespace MLog.Api.Models.Middleware
{
    /// <summary>
    /// RabbitMQ 后台任务
    /// </summary>
    public class RabbitMQWorker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RabbitMQWorker> _logger;
        private IConnection _connection;
        private IModel _channel;

        /// <summary>
        /// RabbitMQ 后台任务 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public RabbitMQWorker(IConfiguration configuration, ILogger<RabbitMQWorker> logger)
        {
            _configuration = configuration;
            _logger = logger;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var _connectionFactory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:HostName"],
                Port = int.Parse(_configuration["RabbitMQ:Port"]),
                UserName = _configuration["RabbitMQ:UserName"],
                Password = _configuration["RabbitMQ:Password"]
            };

            // create connection  
            _connection = _connectionFactory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();

            var exchange = _configuration["RabbitMQ:Logs:Exchange"];
            var queue = _configuration["RabbitMQ:Logs:Queue"];
            var routingKey = _configuration["RabbitMQ:Logs:RoutingKey"];

            _channel.ExchangeDeclare(
                exchange: exchange, 
                type: ExchangeType.Topic,
                durable:true,
                autoDelete:false,
                arguments:null);

            _channel.QueueDeclare(
                queue: queue,
                durable: true, 
                exclusive : false,
                autoDelete: false,
                arguments: null);

            _channel.QueueBind(queue: queue, 
                exchange: exchange, 
                routingKey: routingKey,
                arguments: null);

            _channel.BasicQos(0, 1, false);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                // received message  
                var content = System.Text.Encoding.UTF8.GetString(ea.Body); 
                // handle the received message  
                HandleMessage(content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            var queue = _configuration["RabbitMQ:Logs:Queue"];
            _channel.BasicConsume(queue: queue, false, consumer);

            return Task.CompletedTask;
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="content"></param>
        private void HandleMessage(string content)
        {
            // TODO
            _logger.LogInformation($"consumer received {content}");
        }

        /// <summary>
        /// 有关消费者取消触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) 
        { 
            _logger.LogWarning("有关消费者取消");
        }

        /// <summary>
        /// 消费者未注册触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
            _logger.LogInformation("消费者未注册");
        }

        /// <summary>
        /// 消费者注册完后触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
            _logger.LogInformation("消费者注册完成");
        }

        /// <summary>
        /// 对消费者关闭触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogWarning("对消费者关闭");
        }

        /// <summary>
        /// RabbitMQ连接关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            _logger.LogWarning("RabbitMQ连接关闭");
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public override void Dispose()
        {
            _channel.Close();
            _logger.LogWarning("关闭RabbitMQ通道");
            _connection.Close();
            _logger.LogWarning("关闭RabbitMQ连接");
            base.Dispose();
        }
    }
}
