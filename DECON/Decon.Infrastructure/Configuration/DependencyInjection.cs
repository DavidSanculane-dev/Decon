using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Decon.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Decon.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("DefaultConnection")
                     ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<DeconDbContext>(options =>
                options
                    .UseNpgsql(cs, npgsql =>
                    {
                        npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "decon");
                    })
                    .UseSnakeCaseNamingConvention()
            );

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}

