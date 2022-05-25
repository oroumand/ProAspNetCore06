using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace StateManagement.DistributedCacheSamples.Caching;

public interface ICacheAdapter
{
     T Get<T>(string key);

    void Set<T>(string key, T value);
}


public class DistributedCacheAdapter : ICacheAdapter
{
    private readonly IDistributedCache _cache;

    public DistributedCacheAdapter(IDistributedCache cache)
    {
        _cache = cache;
    }
    public T Get<T>(string key)
    {

        var result = _cache.GetString(key);
        return string.IsNullOrEmpty(result)? default(T): JsonConvert.DeserializeObject<T>(result);

    }

    public void Set<T>(string key, T value)
    {
        string serializedObject = JsonConvert.SerializeObject(value);
        _cache.SetString(key, serializedObject);    
    }
}

public class MemoryCacheAdapter : ICacheAdapter
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheAdapter(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public T Get<T>(string key)
    {
            return _memoryCache.Get<T>(key);
    }

    public void Set<T>(string key, T value)
    {
        _memoryCache.Set(key, value); 
    }
}