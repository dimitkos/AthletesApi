using Application.Infrastructure;
using Infrastructure.Cache;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
#warning
    //https://stackoverflow.com/questions/56143613/inject-generic-interface-in-net-core
    public static class InfrastructureComponent
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlayerDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient(typeof(IQueryPersistence<,>));
            services.AddTransient(typeof(IGetEntity<,>));
            services.AddTransient(typeof(IGetManyEntity<,>));
            services.AddTransient(typeof(IDomainModelPersistence<>));
            services.AddTransient(typeof(ICacheAdapter<,>), typeof(CacheAdapter<,>));

            return services;
        }
    }
}
