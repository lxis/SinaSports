using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Common.Cache
{
    public class CacheManager
    {
        public static async Task<T> Cache<T>(Func<Task<T>> func, CacheStrategy cacheStrategy = null, IList<string> param = null, IList<string> cacheKey = null)
        {
            return await new CacheManagerInternal().Cache<T>(func, param, cacheStrategy, cacheKey);
        }

        public static void RemoveCache(Func<IList<string>, bool> keyJudge, Func<IList<string>, bool> paramsJudge = null)
        {
            new CacheManagerInternal().RemoveCache(keyJudge, paramsJudge);
        }
    }

    public class CacheStorage
    {

        ICacheStorageSaver cacheStorageSaver;
        private static CacheStorage instance = new CacheStorage();
        public static CacheStorage Instance
        {
            get { return instance; }
        }

        public CacheStorage()
        {
            Caches = new List<CacheItem>();
        }

        public async Task LoadFromStorage()
        {
            if (cacheStorageSaver == null)
                throw new ArgumentException("尚未初始化CacheStorage");
            IList<Guid> guids = cacheStorageSaver.LoadStorageCacheGuids();
            foreach (var guid in guids)
            {
                string path = GetPathByGuid(guid);
                CacheItem cacheItem = await cacheStorageSaver.LoadStorageCache<CacheItem>(path);
                caches.Add(cacheItem);
            }
        }

        private string GetPathByGuid(Guid guid)
        {
            return string.Format("Cache/{0}", guid.ToString());
        }

        public void AddCache(CacheItem cacheItem)
        {
            if (cacheStorageSaver == null)
                throw new ArgumentException("尚未初始化CacheStorage");
            caches.Add(cacheItem);
            string path = GetPathByGuid(cacheItem.Guid);
            cacheStorageSaver.SaveStorageCache(cacheItem.Guid, path, cacheItem);

        }

        public void RemoveCache(Guid cacheGuid)
        {
            string path = GetPathByGuid(cacheGuid);
            cacheStorageSaver.DeleteStorageCache(cacheGuid, path);
        }

        private IList<CacheItem> caches;
        /// <summary>
        /// 不要直接在Caches属性上Add，而要用类的Add方法
        /// </summary>
        public IList<CacheItem> Caches
        {
            get
            {
                if (cacheStorageSaver == null)
                    throw new ArgumentException("尚未初始化CacheStorage");
                return caches;
            }
            set { caches = value; }
        }
        public IList<Guid> StorageGuid { get; set; }

        public async Task Init(ICacheStorageSaver saver)
        {
            cacheStorageSaver = saver;
            await LoadFromStorage();
        }
    }

    public class CacheNullException : Exception
    { }

    public class CacheManagerInternal
    {
        CacheStorage cacheStorage = CacheStorage.Instance;

        /// <summary>
        /// 如何判断正确结果和无效结果？用异常判断，然后不存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="param"></param>
        /// <param name="cacheStrategy"></param>
        /// <returns></returns>
        public async Task<T> Cache<T>(Func<Task<T>> func, IList<string> param, CacheStrategy cacheStrategy, IList<string> cacheKey = null)
        {
            if (cacheStrategy == null)
                cacheStrategy = new CacheStrategy { IsSaveStorage = false, IsCache = true, IsUseCacheData = true, CacheTime = new TimeSpan(1, 0, 0, 0) };            
            if (cacheStrategy.IsCache && cacheStrategy.IsUseCacheData)
            {
                var cache = GetCache<T>(param, cacheKey);
                if (cache != null)
                    return cache;

            }
            if (!cacheStrategy.IsFreshCache)
                return default(T);
            var result = await func();
            if (cacheStrategy.IsCache)
                AddCache(result, param, cacheKey, cacheStrategy);
            return result;
        }

        private T GetCache<T>(IList<string> param, IList<string> keys)
        {
            CheckCacheStrategy(cacheStorage.Caches);
            var findedCaches = cacheStorage.Caches.Where(c =>
            {
                //Check Params
                var originalParams = c.CackeKey.Params;
                if (originalParams == null && param == null)
                    return true;
                if (param == null)
                    return false;
                if (originalParams == null)
                    return false;
                if (originalParams.Count != param.Count)
                    return false;
                for (int i = 0; i < originalParams.Count; i++)
                    if (originalParams[i] != param[i])
                        return false;

                //Check keys
                var originalKeys = c.CackeKey.Keys;
                if (originalKeys == null && keys == null)
                    return true;
                if (originalKeys == null)
                    return false;
                if (keys == null)
                    return false;
                if (originalKeys.Count != keys.Count)
                    return false;
                for (int i = 0; i < originalKeys.Count; i++)
                    if (originalKeys[i] != keys[i])
                        return false;

                return true;
            }).ToList();
            var result = FindLatestAndDeleteFormer(findedCaches);
            if (result == null)
                return default(T);
            if (result.Result is T)
                return (T)result.Result;
            else
                return default(T);
        }

        private CacheItem FindLatestAndDeleteFormer(IList<CacheItem> caches)
        {
            var orderList = caches.OrderByDescending(c => c.AddTime).ToList();
            for (int i = orderList.Count - 1; i > 0; i--)
                cacheStorage.RemoveCache(orderList[i].Guid);
            return orderList.FirstOrDefault();
        }

        private void CheckCacheStrategy(IList<CacheItem> findedCaches)
        {
            for (int i = findedCaches.Count - 1; i >= 0; i--)
            {
                if (findedCaches[i] == null) //这个地方很怪，说明是不知道什么时候把null添加到里面去了。所以这也说明null检查需要常态化，只要有可能是null的都应该调用一个封装的检查机制.Check一下
                {
                    findedCaches.RemoveAt(i);
                    continue;
                }

                var strategy = findedCaches[i].CacheStrategy;
                var addTime = findedCaches[i].AddTime;
                if (addTime.Add(strategy.CacheTime) < DateTime.Now)
                {
                    cacheStorage.RemoveCache(findedCaches[i].Guid);
                    findedCaches.RemoveAt(i);
                }
            }
        }

        private void AddCache(object result, IList<string> param, IList<string> keys, CacheStrategy cacheStrategy)
        {
            CacheItem cacheItem = new CacheItem();
            cacheItem.Result = result;
            cacheItem.CackeKey = new CacheKey { Params = param, Keys = keys };
            cacheItem.CacheStrategy = cacheStrategy;
            cacheItem.AddTime = DateTime.Now;
            cacheItem.Guid = Guid.NewGuid();
            cacheStorage.AddCache(cacheItem);
        }

        public void RemoveCache(Func<IList<string>, bool> keyJudge, Func<IList<string>, bool> paramsJudge = null)
        {
            var findedCaches = cacheStorage.Caches.Where(c =>
            {
                if (!keyJudge(c.CackeKey.Keys))
                    return false;
                if (paramsJudge != null && !paramsJudge(c.CackeKey.Params))
                    return false;
                return true;
            });
            foreach (var findedCache in findedCaches)
                cacheStorage.Caches.Remove(findedCache);
        }

    }
}
