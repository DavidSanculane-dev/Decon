using Decon.Domain.Entities;
using Decon.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.Property(p => p.Codigo).HasMaxLength(64).IsRequired();
        builder.Property(p => p.Nome).HasMaxLength(256);

        Decon.Infrastructure.Data.Extensions.ConcurrencyExtensions.UseXminAsConcurrencyToken(builder);

        builder.HasIndex(p => p.Codigo).IsUnique();
    }
}
