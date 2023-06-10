using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EF_DbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                t => t.MigrationsAssembly(typeof(EF_DbContext).Assembly.FullName)),ServiceLifetime.Transient);

            services.AddScoped<IEF_DbContext>(provider => provider.GetService<EF_DbContext>());

            return services;
        }
    }
}
