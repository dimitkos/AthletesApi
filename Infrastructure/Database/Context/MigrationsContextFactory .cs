using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.Context
{
    class MigrationsContextFactory : IDesignTimeDbContextFactory<PlayerDbContext>
    {
        public PlayerDbContext CreateDbContext(string[] args)
        {
#warning try to add ioptions to get connection string
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(@"../Api/"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PlayerDbContext>();
#warning add conection string
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(""));

            return new PlayerDbContext(optionsBuilder.Options);
        }
    }
}
