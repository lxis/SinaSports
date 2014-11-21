using Sina.Sports.Common.Helpers;
using Sina.Sports.Storage.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.UI.WorkerServices.Initializers.TestInitializers
{
    public class TT
    {
        public string AA { get; set; }
    }

    class StorageTestInitializer
    {
        public void Init()
        {
            StorageTest();
        }        

        private async void StorageTest()
        {
            var file = StorageProvider.File(@"test\path");
            var exsit = await file.Exsit();
            //await file.Delete();
            using (var stream = await file.Stream())
            {
                string testString = "hahatest";
                Byte[] testBytes = EncodingHelper.CurrentEncoding.GetBytes(testString);
                stream.Write(testBytes, 0, testBytes.Length);
            }
            var exsit1 = exsit;
            using (var stream = await file.Stream())
            {
                Byte[] readBytes = new Byte[stream.Length];
                stream.Read(readBytes, 0, (int)stream.Length);
                string readString = EncodingHelper.CurrentEncoding.GetString(readBytes, 0, readBytes.Length);
            }

            var file1 = StorageProvider.File(@"aa\model");
            await file1.SaveModel(new TT { AA = "aaa" });
            var model = await file1.LoadModel<TT>();

            TT setting = await StorageProvider.Setting<TT>().Get();
            setting = new TT { AA = "ggg" };            
            await StorageProvider.Setting<TT>().Set(setting);

        }
    }
}
