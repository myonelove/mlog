using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MLog.Api.Models.Enums;
using MLog.Api.Models.Util; 

namespace MLog.Api.Models
{
    /// <summary>
    /// 基础数据类型
    /// </summary>
    public class BasicsResponse<T>
    {
        /// <summary>
        /// 基础数据类型
        /// </summary>
        public BasicsResponse()
        {
            Code = ECode.Ok;
            Message = Code.Desc();
        }

        /// <summary>
        /// 基础数据类型
        /// </summary>
        /// <param name="code">ECode</param>
        public BasicsResponse(ECode code)
        {
            Code = code;
            Message = code.Desc();
            Data = default(T);
        }

        /// <summary>
        /// 基础数据类型
        /// </summary>
        /// <param name="code">ECode</param>
        /// <param name="message">message</param>
        public BasicsResponse(ECode code,string message)
        {
            Code = code;
            Message = message;
            Data = default(T);
        }

        /// <summary>
        /// 基础数据类型
        /// </summary>
        /// <param name="code">ECode</param>
        /// <param name="data">泛型</param>
        public BasicsResponse(ECode code, T data)
        {
            Code = code;
            Message = code.Desc(); 
            if (data == null)
            {
                data = default(T);
            } 
            Data = data;
        }

        /// <summary>
        /// 状态码
        /// </summary> 
        public ECode Code { get;set;}

        /// <summary>
        /// 消息描述
        /// </summary> 
        public string Message { get;set;}

        /// <summary>
        /// 数据类型
        /// </summary>
        public T Data { get;set;}

    }
}
