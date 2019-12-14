using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models
{
    /// <summary>
    /// 登录的数据模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
