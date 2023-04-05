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
            var provider = services.AddDbContext<AprovAtosContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("AprovAtosConnection")))
                .BuildServiceProvider();
            
            var context = provider.GetRequiredService<AprovAtosContext>();
            DbInitializer.Initialize(context);

            return services;
        }
    }
}
