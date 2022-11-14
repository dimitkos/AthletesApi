using Application.Infrastructure;
using Application.Utils.Keys;
using Domain.Aggregates;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries.Players
{
#warning not implemetn retrieve batch
    class GetPlayerEntityPersistence : IGetEntity<Key<long>, Player>/*, IGetManyEntity<Key<long>, Player>*/
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public GetPlayerEntityPersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }

        public async Task<Player> Get(Key<long> entityKey)
        {
            var entity = await GetPlayer(entityKey);

            if (entity == null)
                throw new Exception($"Cannot find entity with id: {entityKey}");

            return entity;
        }

        public async Task<Player?> TryGet(Key<long> entityKey) =>
            await GetPlayer(entityKey);

        public async Task<Player?> GetPlayer(Key<long> entityKey)
        {
            using var context = new PlayerDbContext(_options);

            var player = await context.Players
                .FirstOrDefaultAsync(player => player.Id == entityKey.Value);

            return player;
        }
    }
}
