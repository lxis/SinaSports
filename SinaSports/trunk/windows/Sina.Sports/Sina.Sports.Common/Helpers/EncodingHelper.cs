using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Helpers
{
    /// <summary>
    /// 为了保证编码的一致，因为编码如果出问题，是很难Debug的。
    /// </summary>
    public class EncodingHelper
    {
        public static Encoding CurrentEncoding { get { return Encoding.UTF8; } }
        
    }
}
