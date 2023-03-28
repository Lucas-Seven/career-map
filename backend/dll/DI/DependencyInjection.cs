using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DI
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructureDb(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = services.AddDbContext<DbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")))
                .BuildServiceProvider();
            
            var context = provider.GetRequiredService<DbContext>();
            DbInitializer.Initialize(context);

            return services;
        }
    }
}
