using Decon.Domain.Entities;
using Decon.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class AssetAssignmentConfiguration : IEntityTypeConfiguration<AssetAssignment>
{
    public void Configure(EntityTypeBuilder<AssetAssignment> builder)
    {
        builder.ToTable("asset_assignments");

        builder.Property(p => p.AssetType).HasMaxLength(32).IsRequired();
        builder.Property(p => p.Observacoes).HasMaxLength(512);

        // Corrige ambiguidade especificando o namespace desejado
        Decon.Infrastructure.Data.Extensions.ConcurrencyExtensions.UseXminAsConcurrencyToken(builder);

        // FKs reais para User e Location (ativos são polimórficos => sem FK direta)
        builder.HasOne(p => p.User)
               .WithMany(u => u.Ativos!)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Location)
               .WithMany(l => l.Ativos!)
               .HasForeignKey(p => p.LocationId)
               .OnDelete(DeleteBehavior.Restrict);

        // Índices úteis
        builder.HasIndex(p => new { p.AssetId, p.AssetType });
        builder.HasIndex(p => new { p.UserId, p.LocationId, p.DataAtribuicao });
    }
}