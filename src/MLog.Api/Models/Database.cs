using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class Database
    {
        /// <summary>
        /// 日志库
        /// </summary>
        public const string LogDb = "logdb";

        /// <summary>
        /// 邮件管理,用户管理,调度,其他周边库
        /// </summary>
        public const string ManagerDb = "managerdb";

    }
}
