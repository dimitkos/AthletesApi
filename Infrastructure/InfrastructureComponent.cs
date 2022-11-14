using Application.Infrastructure;
using Infrastructure.Cache;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
#warning
    //https://stackoverflow.com/questions/56143613/inject-generic-interface-in-net-core
    public static class InfrastructureComponent
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlayerDbContext>(options => options.UseSqlServer(connectionString));
#warning check scrutor or autofac to handle it in more elegant way
            Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(item => item.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IQueryPersistence<,>) && !item.IsAbstract && !item.IsInterface))
            .ToList()
            .ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IQueryPersistence<,>));
                services.AddTransient(serviceType, assignedTypes);
            });

            Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(item => item.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IGetEntity<,>) && !item.IsAbstract && !item.IsInterface))
            .ToList()
            .ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IGetEntity<,>));
                services.AddTransient(serviceType, assignedTypes);
            });

            Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(item => item.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IGetManyEntity<,>) && !item.IsAbstract && !item.IsInterface))
            .ToList()
            .ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IGetManyEntity<,>));
                services.AddTransient(serviceType, assignedTypes);
            });

            Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(item => item.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IDomainModelPersistence<>) && !item.IsAbstract && !item.IsInterface))
            .ToList()
            .ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IDomainModelPersistence<>));
                services.AddTransient(serviceType, assignedTypes);
            });
            //services.AddTransient(typeof(IQueryPersistence<,>));
            //services.AddTransient(typeof(IGetEntity<,>));
            //services.AddTransient(typeof(IGetManyEntity<,>));
            //services.AddTransient(typeof(IDomainModelPersistence<>));
            services.AddTransient(typeof(ICacheAdapter<,>), typeof(CacheAdapter<,>));

            return services;
        }
    }
}
