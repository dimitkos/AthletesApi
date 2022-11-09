namespace Application.Infrastructure
{
#warning check if i am going to use tkey
    public interface IGetEntity<TKey, TEntity>
        //where TKey : struct, IEntityKey
        where TEntity : class
    {
        Task<TEntity> Get(TKey entityKey);
        Task<TEntity?> TryGet(TKey entityKey);
    }
}
