using Sina.Sports.Common.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<string> ReadStringAsync(this Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            string text = EncodingHelper.CurrentEncoding.GetString(bytes, 0, bytes.Length);
            return text;
        }

        public static async Task WriteStringAsync(this Stream stream,string text)
        {
            byte[] buffer = EncodingHelper.CurrentEncoding.GetBytes(text);
            await stream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
