namespace Application.Infrastructure
{
#warning check the where
    public interface IGetManyEntity<TKey, TEntity>
    //where TKey : struct, IEntityKey
    {
        Task<Dictionary<TKey, TEntity>> GetMany(TKey[] entityKeys);
    }
}
