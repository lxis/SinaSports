﻿using Sina.Sports.Common.Helpers;
using Sina.Sports.Server.Common;
using Sina.Sports.Server.Common.RequestModel;
using Sina.Sports.Storage.Common;
using System;
using System.Collections.Generic;
using System.IO;
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

        private async Task TestCase()
        {
            Stream netStream = await ClientProvider.Download(new RestRequest { Url = "" });            
            Stream fileStream = await StorageProvider.File(@"Pic\NewPic").Stream();
            await netStream.CopyToAsync(fileStream);

            JsonModel model = new JsonModel();

            await StorageProvider.File(@"Pic\NewPic").SaveModel(model);

            JsonModel model1 = await StorageProvider.File(@"Pic\NewPic").LoadModel<JsonModel>();


            JsonModel model2 = await StorageProvider.Setting<JsonModel>().Get();
            model2.aa = "ffff";
            await StorageProvider.Setting<JsonModel>().Set(model2);

        }
    }




    public class JsonModel
    {
        public string aa { get; set; }
    }
}
