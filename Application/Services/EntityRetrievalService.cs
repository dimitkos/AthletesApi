using Application.Infrastructure;

namespace Application.Services
{
    public interface IEntityRetrievalService<TKey, TEntity>
        where TKey : struct/*, IEntityKey*/
        where TEntity : class
    {
        Task<TEntity> Retrieve(TKey entityKey);
        Task<TEntity?> TryRetrieve(TKey entityKey);
    }

    public class EntityRetrievalService<TKey, TEntity> : IEntityRetrievalService<TKey, TEntity>
        where TKey : struct/*, IEntityKey*/
        where TEntity : class
    {
        private readonly IGetEntity<TKey, TEntity> _fetchEntity;
        private readonly ICacheAdapter<TKey, TEntity> _cache;

        public EntityRetrievalService(IGetEntity<TKey, TEntity> fetchEntity, ICacheAdapter<TKey, TEntity> cache)
        {
            _fetchEntity = fetchEntity;
            _cache = cache;
        }

        public async Task<TEntity> Retrieve(TKey entityKey)
        {
            var entity = await _cache.TryGet(entityKey);

            if (entity is not null)
                return entity;

            return await _fetchEntity.Get(entityKey);
        }

        public async Task<TEntity?> TryRetrieve(TKey entityKey)
        {
            var entity = await _cache.TryGet(entityKey);

            if (entity is not null)
                return entity;

            return await _fetchEntity.TryGet(entityKey);
        }
    }
}
