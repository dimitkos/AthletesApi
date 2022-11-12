using Application.Infrastructure;
using Application.Queries.Players;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Models.Players;

namespace Infrastructure.Persistence.Queries.Players
{
    class GetPlayersPersistencePersistence : IQueryPersistence<GetPlayers, PlayerModel[]>
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public GetPlayersPersistencePersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }

        public async Task<PlayerModel[]> Fetch(GetPlayers query)
        {
            using var context = new PlayerDbContext(_options);

            var players = await context.Players
                .TagWith("GetPlayersPersistencePersistence")
                .Where(player => query.PlayerIds.Contains(player.Id))
                .Select(x => new PlayerModel(
                    x.Id,
                    x.Name,
                    x.Phone,
                    x.CreatedAt,
                    x.UpdatedAt,
                    x.Trophies))
                .ToArrayAsync();

            return players;
        }
    }
}
