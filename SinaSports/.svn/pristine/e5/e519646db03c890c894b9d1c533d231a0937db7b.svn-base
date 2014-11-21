
using Sina.Sports.Server.Common.Imp;
using Sina.Sports.Server.Common.RequestModel;
using Sina.Sports.Server.Common.Sina.CustomExceptions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common
{
    public class ClientProvider
    {
        static IClient instance = new ClientImp(new CommonClient(), new ServerVerifyImp());

        public static Task<T> Message<T>(RestRequest request) where T : class
        {
            return instance.Message<T>(request);            
        }

        public static Task<Stream> Download(RestRequest request)
        {
            return instance.Download(request);            
        }

        public static void Verify(int code, string errorMsg = null)
        {
            instance.Verify(code, errorMsg);
        }
    }
}
