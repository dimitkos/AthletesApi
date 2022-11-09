using Application.Infrastructure;
using Domain.Models;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Commands.Players
{
    class WinTrophyPersistence : IDomainModelPersistence<WinTrophyDomainModel>
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public WinTrophyPersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }

        public async Task Persist(WinTrophyDomainModel domainModel)
        {
            using var context = new PlayerDbContext(_options);

            var playerEntry = context.Entry(domainModel.Player);
            playerEntry.Property(x => x.Trophies).IsModified = true;
            playerEntry.Property(x => x.UpdatedAt).IsModified = true;

            await context.SaveChangesAsync();
        }
    }
}
