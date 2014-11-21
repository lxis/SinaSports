using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.Imp
{
    public class NetworkBrokenException : Exception{ }
    public class NetworkBrokenNotFoundException : NetworkBrokenException { }

    /// <summary>
    /// 一般这个是超时导致的
    /// </summary>
    public class NetworkBrokenCanceledException : NetworkBrokenException { }
    public class NetworkBrokenWeirdException : NetworkBrokenException { }

    public class NetworkBrokenNotFound2Exception : NetworkBrokenException { }

    public class CommonClient :ICommonClient
    {
        public CommonClient()
        {
        }

        HttpClient httpClient = new HttpClient();

        public TimeSpan TimeOut { get { return httpClient.Timeout; } set { httpClient.Timeout = value; } }

        public async Task<string> Get(string url)
        {
            var response = await GetAsyncWrapper(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Post(string url, IDictionary<string, string> requestParam)
        {
            var param = new FormUrlEncodedContent(requestParam);
            var responseMessage = await PostAsyncWrapper(url, param);
            return await responseMessage.Content.ReadAsStringAsync();
        }
        
        public async Task<Stream> Download(string url)
        {
            return await httpClient.GetStreamAsync(url);
        }

        private async Task<HttpResponseMessage> PostAsyncWrapper(string url, HttpContent param)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.PostAsync(url, param);
            }
            catch (HttpRequestException)
            {
                throw new NetworkBrokenNotFound2Exception();
            }
            catch (TaskCanceledException)
            {
                throw new NetworkBrokenCanceledException();
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.GetType() == typeof(Exception) && e.InnerException.Message == "Metadata file is invalid or corrupted. (Exception from HRESULT: 0x80000012)")
                    throw new NetworkBrokenWeirdException();
                throw;
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NetworkBrokenNotFoundException();
            return response;
        }

        private async Task<HttpResponseMessage> GetAsyncWrapper(string url)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(url);
            }
            catch(HttpRequestException)
            {
                throw new NetworkBrokenNotFound2Exception();
            }
            catch(TaskCanceledException)
            {
                throw new NetworkBrokenCanceledException();
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.GetType() == typeof(Exception) && e.InnerException.Message == "Metadata file is invalid or corrupted. (Exception from HRESULT: 0x80000012)")
                    throw new NetworkBrokenWeirdException();
                throw;
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NetworkBrokenNotFoundException();
            return response;
        }
    }
}
