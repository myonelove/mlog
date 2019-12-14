using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models.Util
{
    /// <summary>
    /// 时间日期扩展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// DateTime转时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ConvertToLong(this DateTime date)
        {
            var startTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Utc);
            return (new DateTimeOffset(date).UtcTicks - startTime.Ticks) / 10000;
        }

        /// <summary>
        /// 时间戳转DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(this long timestamp)
        {
            var startTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            return startTime.Add(new TimeSpan(timestamp * 10000));
        }
    }
}
