using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MLog.Api.Models
{
    /// <summary>
    /// 日志相信信息
    /// </summary>
    public class LogInfo:LogCategory
    {
        /// <summary>
        /// Id
        /// </summary>
        public ObjectId Id { get;set;}

        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message { get;set;}

        /// <summary>
        /// 详细信息
        /// </summary>
        public string Detail { get;set;}

        /// <summary>
        /// 创建记录时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
