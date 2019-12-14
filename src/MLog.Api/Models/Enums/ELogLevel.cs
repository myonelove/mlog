using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models.Enums
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum ELogLevel
    {
        /// <summary>
        /// debug 级别最低
        /// </summary>
        [Description("DEBUG")]
        DEBUG = 0,

        /// <summary>
        /// info 重要，输出信息
        /// </summary>
        [Description("INFO")]
        INFO = 1,

        /// <summary>
        /// warn ,严重
        /// </summary>
        [Description("WARN")]
        WARN = 2,

        /// <summary>
        /// error,相对严重
        /// </summary>
        [Description("ERROR")]
        ERROR = 4,

        /// <summary>
        /// fatal, 非常严重
        /// </summary>
        [Description("FATAL")]
        FATAL = 8

    }
}
