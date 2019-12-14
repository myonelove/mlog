using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models.Request
{
    /// <summary>
    /// 注册用户的请求参数
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        public string NickName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get;set;}

        /// <summary>
        /// 创建时间
        /// </summary> 
        public DateTime Createtime { get;set;} = DateTime.Now;

    }
}
