using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Yans.Base.Domain;

public static class DistributedCacheExtensions
{
    public async static Task<T?> GetAsync<T>(this IDistributedCache cache, string key)
    {
        byte[]? cachedData = await cache.GetAsync(key);

        if (cachedData != null)
        {
            string serializedData = Encoding.UTF8.GetString(cachedData);
            return JsonSerializer.Deserialize<T>(serializedData);
        }

        return default;
    }

    public static async Task SetAsync<T>(this IDistributedCache cache, string key, T value, DistributedCacheEntryOptions options)
    {
        string serializedData = JsonSerializer.Serialize(value);
        byte[] dataBytes = Encoding.UTF8.GetBytes(serializedData);
        await cache.SetAsync(key, dataBytes, options);
    }
}
