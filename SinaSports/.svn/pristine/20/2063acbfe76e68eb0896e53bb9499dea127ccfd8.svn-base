using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Cache
{
    public interface ICacheStorageSaver
    {
        IList<Guid> LoadStorageCacheGuids();

        Task<T> LoadStorageCache<T>(string path);

        void SaveStorageCache(Guid guid, string path, object cacheItem);

        void DeleteStorageCache(Guid guid, string path);
    }
}
