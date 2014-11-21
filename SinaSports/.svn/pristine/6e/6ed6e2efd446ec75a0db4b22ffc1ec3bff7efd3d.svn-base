using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common
{
    public interface ICommonClient
    {
        TimeSpan TimeOut { get; set; }

        Task<string> Get(string url);

        Task<string> Post(string url, IDictionary<string, string> requestParam);

        Task<Stream> Download(string url);
    }
}
