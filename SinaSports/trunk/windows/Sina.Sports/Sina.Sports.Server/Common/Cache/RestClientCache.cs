﻿using Sina.Sports.Common.Cache;
using Sina.Sports.Server.Common.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sina.Sports.Server.Common.Cache
{
    public class RestClientCache
    {
        public async Task<T> Cache<T>(RestRequest request, Func<Task<T>> func) where T : class
        {
            return await CacheManager.Cache<T>(func, request.CacheStrategy, GenerateCacheParam(request), GenerateCacheKey());
        }

        private IList<string> GenerateCacheParam(RestRequest request)
        {
            IList<string> cacheParam = new List<string>();
            cacheParam.Add(request.IsReturnHeader.ToString());
            cacheParam.Add(request.Type.ToString());
            if (request.ParamDic != null)
                foreach (var param in request.ParamDic)
                {
                    cacheParam.Add(param.Key);
                    cacheParam.Add(param.Value.ToString());
                }
            cacheParam.Add(request.Url);
            return cacheParam;
        }

        private IList<string> GenerateCacheKey()
        {
            IList<string> cacheKey = new List<string>();
            cacheKey.Add("NetWorkCache==");
            return cacheKey;
        }
    }
}
