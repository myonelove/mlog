using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models.Enums
{
    /// <summary>
    /// 状态码
    /// </summary>
    public enum ECode:int
    {
        #region base

        /// <summary>
        /// 失败
        /// </summary>
        [Description("Fail")]
        Fail = 0,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("Ok")]
        Ok = 1,

        #endregion

        #region 业务提示 100xxx

        #endregion

        #region 异常提示 500xxx

        #endregion
    }
}
