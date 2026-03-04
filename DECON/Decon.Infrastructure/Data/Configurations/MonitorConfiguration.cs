using Decon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitor = Decon.Domain.Entities.Monitor;

namespace Decon.Infrastructure.Data.Configurations;

public class MonitorConfiguration : AssetConfigurationBase<Monitor>
{
    public override void Configure(EntityTypeBuilder<Monitor> builder)
    {
        base.Configure(builder);

        builder.ToTable("monitors");

        builder.Property(p => p.EmpresaId).HasMaxLength(64);
    }
}
