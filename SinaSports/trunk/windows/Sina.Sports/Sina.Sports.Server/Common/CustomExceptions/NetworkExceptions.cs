using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.CustomExceptions
{

    public class NetworkBrokenException : Exception { }
    public class NetworkBrokenNotFoundException : NetworkBrokenException { }

    /// <summary>
    /// 一般这个是超时导致的
    /// </summary>
    public class NetworkBrokenCanceledException : NetworkBrokenException { }
    public class NetworkBrokenWeirdException : NetworkBrokenException { }

    public class NetworkBrokenNotFound2Exception : NetworkBrokenException { }
}
