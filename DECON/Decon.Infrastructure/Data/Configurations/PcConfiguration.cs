using Decon.Domain.Entities;
using Decon.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class PcConfiguration : AssetConfigurationBase<PC>
{
    public override void Configure(EntityTypeBuilder<PC> builder)
    {
        base.Configure(builder);

        builder.ToTable("pcs");

        builder.Property(p => p.IntuneName).HasMaxLength(128);
        builder.Property(p => p.CPU).HasMaxLength(64);
        builder.Property(p => p.Disk).HasMaxLength(32);
        builder.Property(p => p.RAM).HasMaxLength(16);

        builder.Property(p => p.FormFactor)
               .HasConversion<string>()
               .HasMaxLength(32)
               .HasDefaultValue(FormFactorPC.Portatil);

        // Index de pesquisa rápida
        builder.HasIndex(p => new { p.Nome, p.CentroCusto });
    }
}