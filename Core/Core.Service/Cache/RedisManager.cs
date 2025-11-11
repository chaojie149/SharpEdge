using StackExchange.Redis;

namespace Core.Service.Cache;

public class RedisManager(IConnectionMultiplexer connection) : IRedisManager
{
    private readonly IDatabase _db = connection.GetDatabase();

    private string Key(string key) => key; // 不加前缀

    public IDatabase Database => _db;
    public ISubscriber Subscriber => connection.GetSubscriber();

    // === 基础 Key 操作 ===
    public Task<bool> KeyExistsAsync(string key) => _db.KeyExistsAsync(Key(key));
    public Task<bool> KeyDeleteAsync(string key) => _db.KeyDeleteAsync(Key(key));
    public Task<bool> KeyExpireAsync(string key, TimeSpan? expiry) => _db.KeyExpireAsync(Key(key), expiry);

    // === 字符串操作 ===
    public Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = null)
        => _db.StringSetAsync(Key(key), value, expiry);

    public async Task<string?> StringGetAsync(string key)
    {
        var val = await _db.StringGetAsync(Key(key));
        return val.HasValue ? val.ToString() : null;
    }

    public Task<long> StringIncrementAsync(string key, long value = 1)
        => _db.StringIncrementAsync(Key(key), value);

    // === Hash 操作 ===
    public Task<HashEntry[]> HashGetAllAsync(string key)
        => _db.HashGetAllAsync(Key(key));

    public Task HashSetAsync(string key, string field, string value)
        => _db.HashSetAsync(Key(key), new HashEntry[] { new(field, value) });

    public async Task<string?> HashGetAsync(string key, string field)
    {
        var val = await _db.HashGetAsync(Key(key), field);
        return val.HasValue ? val.ToString() : null;
    }

    // === Pub/Sub ===
    public Task PublishAsync(string channel, string message)
        => Subscriber.PublishAsync(channel, message);

    public Task SubscribeAsync(string channel, Action<RedisChannel, RedisValue> handler)
        => Subscriber.SubscribeAsync(channel, handler);

    // === 事务 ===
    public ITransaction CreateTransaction() => _db.CreateTransaction();

    // === 管理工具（仅内部调试使用） ===
    public IServer? GetServer()
    {
        var endpoints = connection.GetEndPoints();
        return endpoints.Length > 0 ? connection.GetServer(endpoints[0]) : null;
    }
}
