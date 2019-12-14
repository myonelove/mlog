using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Websockets
{
    /// <summary>
    /// websocket request class
    /// </summary>
    public class WebSocketRequest
    {
        /// <summary>
        /// 路由路径 如："/push/logs" ,"/push/message" ...
        /// </summary>
        public string Route { get;set;}

        /// <summary>
        /// 请求的数据
        /// </summary>
        public object Body { get;set;}

    }
}
