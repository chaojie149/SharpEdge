using System;
using System.Threading.Tasks;

namespace Core.Persistent.Caching;

public interface IQueryCacheService
{
    Task<T?> GetOrCreateAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? expiration = null);
    
    void Remove(string key);
    void RemoveByPattern(string pattern);
}
