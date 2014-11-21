using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.CustomExceptions
{
    public class ParseJsonException:Exception
    {
        public string Json { get; set; }

        public ParseJsonException(string message, string json, Exception ex)
            : base(message, ex)
        {
            Json = json;
        }
    }
}
