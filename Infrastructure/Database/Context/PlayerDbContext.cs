#nullable disable
using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Database.Context
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
