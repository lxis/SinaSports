
using Sina.Sports.Server.Common.CustomExceptions;
using Sina.Sports.Server.Common.RequestModel;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common
{
    public interface IClient : IJsonVerifyer
    {
        Task<T> Message<T>(RestRequest request) where T : class;
        Task<Stream> Download(RestRequest request);
    }
}
