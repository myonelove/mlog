using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Websockets
{
    /// <summary>
    /// 路由路径
    /// </summary>
    public class RoutePath
    {
        /// <summary>
        /// 加载默认的日志信息
        /// </summary>
        public const string LoadDefaultLogs = "/logs/default";

        /// <summary>
        /// 推送新的日志信息
        /// </summary>
        public const string PushNewLogs = "/logs/push/new";

    }
}
