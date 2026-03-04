using Decon.Domain.Entities;
using Decon.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class AssetHistoryConfiguration : IEntityTypeConfiguration<AssetHistory>
{
    public void Configure(EntityTypeBuilder<AssetHistory> builder)
    {
        builder.ToTable("asset_histories");

        builder.Property(p => p.AssetType).HasMaxLength(32).IsRequired();
        builder.Property(p => p.AlteradoPor).HasMaxLength(256);
        builder.Property(p => p.Observacoes).HasMaxLength(1024);

        // armazenar enums como string
        builder.Property(p => p.EstadoAnterior).HasConversion<string>().HasMaxLength(32);
        builder.Property(p => p.EstadoNovo).HasConversion<string>().HasMaxLength(32);

        
        // Corrige ambiguidade especificando o namespace desejado
        Decon.Infrastructure.Data.Extensions.ConcurrencyExtensions.UseXminAsConcurrencyToken(builder);

        builder.HasIndex(p => new { p.AssetId, p.AssetType, p.CriadoEm });
    }
}
