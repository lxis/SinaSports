using Sina.Sports.Storage.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Storage.Universal.Common.Imp
{
    public class SettingImp<T> : ISetting<T> where T : new()
    {
        private string key { get { return typeof(T).FullName; } }

        private string configBaseFolder = "Settings";

        public async Task<T> Get()
        {
            var t = await Read();
            return t;
        }

        /// <summary>
        /// 存储业务model
        /// </summary>
        /// <param name="key"></param>
        /// <param name="model">业务model,为null可以删除key</param>
        /// <exception cref="TypeErrorException">Key对应的model与需要的model不一致</exception>
        public async Task Set(T model)
        {
            await Write(model);
        }

        private async Task Write(object model)
        {
            var file = StorageProvider.File(Path.Combine(configBaseFolder,key));
            await file.SaveModel(model);
        }

        private async Task<T> Read()
        {
            var file = StorageProvider.File(Path.Combine(configBaseFolder, key));
            return await file.LoadModel<T>();
        }
    }
}
