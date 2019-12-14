using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models.Util
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string Desc(this Enum @enum)
        {
            var type = @enum.GetType();
            var memberInfo = type.GetMember(@enum.ToString());
            var attributes = memberInfo.FirstOrDefault().GetCustomAttributes(typeof(DescriptionAttribute),false);
            if (!attributes.Any())
            {
                return @enum.ToString();
            }
            return (attributes.SingleOrDefault() as DescriptionAttribute).Description;
        } 
    }
}
