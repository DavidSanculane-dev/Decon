using Decon.Domain.Entities;
using Decon.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.Property(p => p.Nome).HasMaxLength(128).IsRequired();
        builder.Property(p => p.Descricao).HasMaxLength(256);

        Decon.Infrastructure.Data.Extensions.ConcurrencyExtensions.UseXminAsConcurrencyToken(builder);

        builder.HasIndex(p => p.Nome).IsUnique();
    }
}
