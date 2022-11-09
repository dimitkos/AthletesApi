using Application.Infrastructure;
using Domain.Models;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Commands.Players
{
    class AddPlayerPersistence : IDomainModelPersistence<AddPlayerDomainModel>
    {
        private readonly DbContextOptions<PlayerDbContext> _options;

        public AddPlayerPersistence(DbContextOptions<PlayerDbContext> options)
        {
            _options = options;
        }

        public async Task Persist(AddPlayerDomainModel domainModel)
        {
            using var context = new PlayerDbContext(_options);

            context.Players.Add(domainModel.Player);
            await context.SaveChangesAsync();
        }
    }
}
