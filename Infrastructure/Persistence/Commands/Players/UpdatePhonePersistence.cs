using Application.Infrastructure;
using Domain.Models;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Commands.Players
{
    class UpdatePhonePersistence : IDomainModelPersistence<UpdatePhoneDomainModel>
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public UpdatePhonePersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }

        public async Task Persist(UpdatePhoneDomainModel domainModel)
        {
            using var context = new PlayerDbContext(_options);

            var playerEntry = context.Entry(domainModel.Player);
            playerEntry.Property(x => x.Phone).IsModified = true;
            playerEntry.Property(x => x.UpdatedAt).IsModified = true;

            await context.SaveChangesAsync();
        }
    }
}
