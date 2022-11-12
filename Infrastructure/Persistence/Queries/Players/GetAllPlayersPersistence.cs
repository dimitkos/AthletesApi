using Application.Infrastructure;
using Application.Queries.Players;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Models.Players;

namespace Infrastructure.Persistence.Queries.Players
{
    class GetAllPlayersPersistence : IQueryPersistence<GetAllPlayers, PlayerModel[]>
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public GetAllPlayersPersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }

        public async Task<PlayerModel[]> Fetch(GetAllPlayers query)
        {
            using var context = new PlayerDbContext(_options);

            var players = await context.Players
                .TagWith("GetAllPlayersPersistence")
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
