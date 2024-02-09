using Distributedsqlservercache.InterFaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Distributedsqlservercache.Classes
{
    public class DistributedCachAdapter : IDistributedCachAdapter
    {
        private readonly IDistributedCache distributedCache;

        public DistributedCachAdapter(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public T Get<T>(string Key)
        {
            var result = distributedCache.GetString(Key);
            return JsonConvert.DeserializeObject<T>(result);
        }

        public void Set<T>(string key, T value)
        {
            var result = JsonConvert.SerializeObject(value);
            distributedCache.SetString(key, result);
        }
    }
}
