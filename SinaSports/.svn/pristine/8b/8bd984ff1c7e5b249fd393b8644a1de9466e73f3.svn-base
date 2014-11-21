using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Storage.Common
{
    public interface ISetting<T> where T : new()
    {
        Task<T> Get();
        Task Set(T model);
    }
}
