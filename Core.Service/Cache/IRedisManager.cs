using StackExchange.Redis;


using StackExchange.Redis;

namespace Core.Service.Cache;

public interface IRedisManager
{
    IDatabase Database { get; }
    ISubscriber Subscriber { get; }

    Task<bool> KeyExistsAsync(string key);
    Task<bool> KeyDeleteAsync(string key);
    Task<bool> KeyExpireAsync(string key, TimeSpan? expiry);

    Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = null);
    Task<string?> StringGetAsync(string key);
    Task<long> StringIncrementAsync(string key, long value = 1);

    Task<HashEntry[]> HashGetAllAsync(string key);
    Task HashSetAsync(string key, string field, string value);
    Task<string?> HashGetAsync(string key, string field);

    Task PublishAsync(string channel, string message);
    Task SubscribeAsync(string channel, Action<RedisChannel, RedisValue> handler);

    ITransaction CreateTransaction();
    IServer? GetServer();
}
