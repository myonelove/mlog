using MLog.Api.Models.Enums;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models
{
    /// <summary>
    /// 日志分类,日志分析统计维度表
    /// </summary>
    public class LogCategory
    {
        /// <summary>
        /// id
        /// </summary>
        public ObjectId CategoryId { get;set;}

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Host { get; set; }
    
        /// <summary>
        /// 服务
        /// </summary>
        public string Service { get; set; }
        
        /// <summary>
        /// 全面类(命名空间+类)
        /// </summary>
        public string FullClass { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public ELogLevel LogLevel { get;set;}

    }
}
