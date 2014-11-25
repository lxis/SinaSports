using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Cache
{
    public class CacheStrategy
    {
        public CacheStrategy()
        {
            IsUseCacheData = true;
            IsCache = true;
            IsSaveStorage = true;
            CacheTime = new TimeSpan(1, 0, 0, 0);
            IsFreshCache = true;
        }

        public bool IsUseCacheData { get; set; }
        public bool IsCache { get; set; }

        public TimeSpan CacheTime { get; set; }

        public bool IsSaveStorage { get; set; }

        public bool IsFreshCache { get; set; }
    }

    public class CacheKey
    {
        public IList<string> Keys { get; set; }

        public IList<string> Params { get; set; }
    }

    public class CacheItem
    {
        public object Result { get; set; }

        public CacheKey CackeKey { get; set; }

        public CacheStrategy CacheStrategy { get; set; }

        public DateTime AddTime { get; set; }

        public Guid Guid { get; set; }
    }
}
