
using System;
using System.Diagnostics;
using System.IO;
using Windows.Storage;

using System.Threading.Tasks;
using Sina.Sports.Storage.Common;
using Sina.Sports.Common.Helpers;
using Sina.Sports.Common.JsonConverter;
using Newtonsoft.Json;
using Sina.Sports.Common.Extensions;

namespace Sina.Sports.Storage.Universal.Common.Imp
{
    public class FileImp : IFile
    {
        public string Path { get { return path; } }

        string path;
        public FileImp(string path)
        {            
            this.path = path;
            InitBaseFolder();
        }

        StorageFolder baseFolder;

        /// <summary>
        /// 这个是临时写的，会改
        /// </summary>
        private void InitBaseFolder()
        {
            baseFolder = ApplicationData.Current.LocalFolder;
        }

        public async Task<bool> Exsit()
        {            
            try
            {
                var sampleFile = await baseFolder.GetFileAsync(path);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        private async Task<bool> FolderExsit()
        {
            try
            {
                var folder = System.IO.Path.GetDirectoryName(path);
                var sampleFile = await baseFolder.GetFolderAsync(folder);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public async Task<Stream> Stream(bool readOnly = false)
        {
            //这里分几种情况，一是没有文件夹，二是没有文件，三是有文件。读取方式也是分只读和非只读
            //没有文件夹,如果是只读，直接报错，如果非只读，建个文件夹建个文件然后返回。
            //有文件夹没有文件，如果只读直接报错，如果非只读，建个文件然后返回。
            //有文件，根据只读与否返回
            if (await FolderExsit())
            {
                if (await Exsit())
                {
                    StorageFile file = await baseFolder.GetFileAsync(path);
                    if (readOnly)
                        return await file.OpenStreamForReadAsync();
                    else
                        return await file.OpenStreamForWriteAsync();
                }
                else
                {
                    if (readOnly)
                        throw new ArgumentException("文件不存在，只读方式获取Stream是无意义的");
                    var file = await baseFolder.CreateFileAsync(path);
                    return await file.OpenStreamForWriteAsync();
                }
            }
            else
            {
                if (readOnly)
                    throw new ArgumentException("文件夹不存在，只读方式获取Stream是无意义的");
                var folder = System.IO.Path.GetDirectoryName(path);
                await baseFolder.CreateFolderAsync(folder);
                var file = await baseFolder.CreateFileAsync(path);
                return await file.OpenStreamForWriteAsync();
            }
        }

        public async Task<T> LoadModel<T>()
        {
            if (!await Exsit())
                return default(T);
            using (Stream stream = await Stream(true))
            {
                string json = await stream.ReadStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public async Task SaveModel(object model)
        {
            using (Stream stream = await Stream())
            {
                string json = JsonConvert.SerializeObject(model);
                await stream.WriteStringAsync(json);
            }
        }

        public async Task Delete()
        {
            var file = await baseFolder.GetFileAsync(Path);
            await file.DeleteAsync();
        }
    }
}
