namespace Application.Infrastructure
{
#warning check the where
#warning maybe not need this
    public interface IGetManyEntity<TKey, TEntity>
    //where TKey : struct, IEntityKey
    {
        Task<Dictionary<TKey, TEntity>> GetMany(TKey[] entityKeys);
    }
}
