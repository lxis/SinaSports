
using Sina.Sports.Storage.Universal.Common.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Storage.Common
{
    public class StorageProvider
    {
        /// <summary>
        /// 根据文件路径返回文件
        /// </summary>
        /// <param name="path">文件路径,如果路径的文件夹不存在,访问StorageFile的WriteStream的时候会创建文件夹</param>
        public static IFile File(string path)
        {
            return new FileImp(path);
        }

        public static ISetting<T> Setting<T>() where T : new()
        {
            return new SettingImp<T>();
        }
    }
}
