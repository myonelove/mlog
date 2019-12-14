using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MLog.Api.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public ObjectId Id { get;set;}

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get;set;}

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get;set;}

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get;set;}

    }
}
