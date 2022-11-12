using Application.Infrastructure;
using Application.Queries.Players;
using Domain.Aggregates;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries.Players
{
    class SearchPlayersPersistence : IQueryPersistence<SearchPlayers, long[]>
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public SearchPlayersPersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }
#warning review again
        public async Task<long[]> Fetch(SearchPlayers query)
        {
            using var context = new PlayerDbContext(_options);

            var players = context.Players as IQueryable<Player>;

            if (query.TrophiesFrom.HasValue)
                players.Where(x => x.Trophies >= query.TrophiesFrom);

            if (query.TrophiesTo.HasValue)
                players.Where(x => x.Trophies <= query.TrophiesTo);

            if (query.DateFrom.HasValue)
                players.Where(x => x.CreatedAt >= query.DateFrom);

            if (query.DateTo.HasValue)
                players.Where(x => x.CreatedAt <= query.DateTo);

            if (query.Skip.HasValue && query.Take.HasValue)
                players.OrderBy(x => x.Id).Skip(query.Skip.Value).Take(query.Take.Value);

            return await players
                .Select(x => x.Id)
                .ToArrayAsync();
        }
    }
}
