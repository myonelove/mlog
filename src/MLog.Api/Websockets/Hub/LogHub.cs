using MLog.Api.Websockets.Handle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace MLog.Api.Websockets.Hub
{
    /// <summary>
    /// 日志处理程序
    /// </summary>
    public class LogHub: WebSocketBehavior
    {
        private string _name;

        /// <summary>
        /// open
        /// </summary>
        protected override void OnOpen()
        {
            base.OnOpen(); 
            Send("连上websocket");
        }

        /// <summary>
        /// close
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }

        /// <summary>
        /// error
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
        }

        /// <summary>
        /// message
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.IsText) //字符串数据
            {
                try
                {
                    var request = JsonConvert.DeserializeObject<WebSocketRequest>(e.Data);
                    request.AddLoadDefaultLogs();



                }
                catch (Exception ex)
                {
                    Send($"接受到的数据{e.Data}  异常：{ex}");
                }
            }
            else if (e.IsBinary) //二进制数据
            {
                // TODO 
            }
            else if (e.IsPing) //ping
            {
                // TODO
            } 

        }

    }
}
