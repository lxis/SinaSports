using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.CustomExceptions
{
    /// <summary>
    /// 调用webservice接口,服务端返回的异常
    /// </summary>
    public class RestServiceException<T> : Exception where T : FaultBase
    {
        public RestServiceException(T fault) : base(fault.ErrorMsg) { }
    }
}
