using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Core.Persistent.Caching;

public class QueryCacheService : IQueryCacheService
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<QueryCacheService> _logger;
    private readonly HashSet<string> _cacheKeys = new();
    private readonly object _lock = new();

    public QueryCacheService(
        IMemoryCache cache,
        ILogger<QueryCacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetOrCreateAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? expiration = null)
    {
        if (_cache.TryGetValue(key, out T? cachedValue))
        {
            _logger.LogDebug("Cache hit for key: {Key}", key);
            return cachedValue;
        }

        var value = await factory();

        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(5)
        };

        _cache.Set(key, value, options);

        lock (_lock)
        {
            _cacheKeys.Add(key);
        }

        _logger.LogDebug("Cache miss for key: {Key}, value cached", key);
        return value;
    }

    public void Remove(string key)
    {
        _cache.Remove(key);
        lock (_lock)
        {
            _cacheKeys.Remove(key);
        }
        _logger.LogDebug("Cache removed for key: {Key}", key);
    }

    public void RemoveByPattern(string pattern)
    {
        List<string> keysToRemove;
        lock (_lock)
        {
            keysToRemove = _cacheKeys
                .Where(k => k.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        foreach (var key in keysToRemove)
        {
            Remove(key);
        }

        _logger.LogDebug("Removed {Count} cache entries matching pattern: {Pattern}",
            keysToRemove.Count, pattern);
    }
}