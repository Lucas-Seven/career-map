using dll.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dll.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructureDb(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = services.AddDbContext<CareerMapContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("CareerMapConnection")))
                .BuildServiceProvider();
            
            var context = provider.GetRequiredService<CareerMapContext>();
            DbInitializer.Initialize(context);

            return services;
        }
    }
}
