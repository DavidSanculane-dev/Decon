using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Decon.Infrastructure.Data;


namespace Decon.Infrastructure.Data;

public class DeconDbContextFactory : IDesignTimeDbContextFactory<DeconDbContext>
{
    public DeconDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DeconDbContext>();

        // ⚠️ USA uma connection string direta APENAS para migrations
        var connectionString =
            "Host=localhost;Port=5432;Database=decon_db;Username=postgres;Password=SenhaSuperSecreta!";

        optionsBuilder
            .UseNpgsql(connectionString, npgsql =>
            {
                npgsql.MigrationsHistoryTable("__EFMigrationsHistory", "decon");
            })
            .UseSnakeCaseNamingConvention();

        return new DeconDbContext(optionsBuilder.Options);
    }
}