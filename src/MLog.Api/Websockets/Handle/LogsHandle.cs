using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Websockets.Handle
{
    /// <summary>
    /// 日志处理
    /// </summary>
    public static class LogsHandle
    {
        /// <summary>
        /// 加载最新的20条日志信息(从数据库中加载)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static WebSocketRequest AddLoadDefaultLogs(this WebSocketRequest request)
        {
            if (RoutePath.LoadDefaultLogs == request.Route.Trim().ToLower())
            {
                try
                {

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return request;
        }

        /// <summary>
        /// 推送最新的日志（rabbitmq推送过来的日志）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static WebSocketRequest AddPushNewLogs(this WebSocketRequest request)
        {
            if (RoutePath.PushNewLogs == request.Route.Trim().ToLower())
            {
                try
                {

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return request;
        }
         

    }

}
