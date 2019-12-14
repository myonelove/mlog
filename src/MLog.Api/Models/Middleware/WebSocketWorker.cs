using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MLog.Api.Websockets;
using MLog.Api.Websockets.Hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace MLog.Api.Models.Middleware
{
    /// <summary>
    /// WebSocket后台工作任务
    /// </summary>
    public class WebSocketWorker:BackgroundService
    {
        private readonly ILogger<WebSocketWorker> _logger;
        private readonly WebSocketServer wssv;

        /// <summary>
        /// WebSocket后台工作任务
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param> 
        public WebSocketWorker( IConfiguration configuration, ILogger<WebSocketWorker> logger)
        {
            _logger = logger; 
            var url = configuration["WebSocketHost"]; 
            wssv = new WebSocketServer($"ws://{url}");
        }
         
        /// <summary>
        /// 开始任务
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StartAsync(CancellationToken cancellationToken)
        { 
            wssv.AddWebSocketService<LogHub>("/loghub");
            wssv.Start();

            _logger.LogInformation("websocket 启动");
            return base.StartAsync(cancellationToken);
        }
         
        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            wssv.Stop();
            _logger.LogInformation("websocket停止");
            return base.StopAsync(cancellationToken);
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
             return Task.Delay(1);
        }
    }
}
