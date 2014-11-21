using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Storage.Common
{
    public interface IFile
    {
        string Path { get; }
        Task<bool> Exsit();
        Task<Stream> Stream(bool readOnly = false);
        Task SaveModel(object model);
        Task<T> LoadModel<T>();
        Task Delete();
    }
}
