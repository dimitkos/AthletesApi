using Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
#warning is so complicated this solution
    public interface IEntityStoreService<TKey, TEntity>
        where TKey : struct/*, IEntityKey*/
        where TEntity : class
    {
        Task Store(TEntity entity);
    }

    public class EntityStoreService<TKey, TEntity> : IEntityStoreService<TKey, TEntity>
        where TKey : struct/*, IEntityKey*/
        where TEntity : class
    {
#warning consider again this solution need a cache proxy or remove domain model
        //private readonly IDomainModelPersistence<TDomainModel> _fetchEntity;
        //private readonly ICacheAdapter<TKey, TEntity> _cache;


        public Task Store(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
