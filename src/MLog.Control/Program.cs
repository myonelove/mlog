using RabbitMQ.Client;
using System;
using System.Text;

namespace MLog.Control
{
    class Program
    {
        static void Main(string[] args)
        {

            IConnectionFactory connFactory = new ConnectionFactory//创建连接工厂对象
            {
                HostName = "localhost",//IP地址
                Port = 5672,//端口号
                UserName = "guest",//用户账号
                Password = "guest"//用户密码
            };

            using (IConnection conn = connFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    //交换机名称
                    String exchangeName = "mlog.exchange";
                    //路由名称
                    String routeKey = "mlog.queue.control";
                    //声明交换机   路由交换机类型direct
                    channel.ExchangeDeclare(
                        exchange: exchangeName, 
                        type: ExchangeType.Topic,
                        durable:true,
                        autoDelete:false,
                        arguments:null);

                    var properties = channel.CreateBasicProperties();

                    while (true)
                    {
                        Console.WriteLine("消息内容:");
                        String message = Console.ReadLine();
                        //消息内容
                        byte[] body = Encoding.UTF8.GetBytes(message);
                        //发送消息  发送到路由匹配的消息队列中
                        channel.BasicPublish(
                            exchange: exchangeName, 
                            routingKey: routeKey, 
                            basicProperties: properties, 
                            body: body);
                        
                        Console.WriteLine("成功发送消息:" + message);
                    }
                }
            }
             
        }
    }
}
