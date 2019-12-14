using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MLog.Api.Models
{
    /// <summary>
    /// session user
    /// </summary>
    public class SessionUser
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get;set;}

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get;set;}

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

    }
}
