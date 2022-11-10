using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Cache
{
    public interface ICacheAdapter<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        Task<TEntity?> TryGet(TKey key);
        Task Add(TKey key, TEntity? entity);
        Task Remove(TKey key);
    }

#warning check to handle IEntityKey
    class CacheAdapter<TKey, TEntity> : ICacheAdapter<TKey, TEntity>
        where TKey : struct /*IEntityKey*/
        where TEntity : class
    {
        private readonly IMemoryCache _memoryCache;

        public CacheAdapter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task Add(TKey key, TEntity? entity)
        {
            _memoryCache.Set(key, entity);
            return Task.CompletedTask;
        }

        public Task Remove(TKey key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }

        public Task<TEntity?> TryGet(TKey key)
        {
            if (_memoryCache.TryGetValue(key, out var value))
                return Task.FromResult((TEntity?)value);

            return Task.FromResult<TEntity?>(null);
        }
    }
}
