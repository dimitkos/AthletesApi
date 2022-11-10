namespace Application.Infrastructure
{
    public interface ICacheAdapter<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        Task<TEntity?> TryGet(TKey key);
        Task Add(TKey key, TEntity? entity);
        Task Remove(TKey key);
    }
}
