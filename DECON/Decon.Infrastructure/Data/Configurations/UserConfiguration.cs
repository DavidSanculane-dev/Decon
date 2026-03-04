using Decon.Domain.Entities;
using Decon.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(p => p.NomeCompleto).HasMaxLength(256).IsRequired();
        builder.Property(p => p.NumeroInterno).HasMaxLength(64);

        Decon.Infrastructure.Data.Extensions.ConcurrencyExtensions.UseXminAsConcurrencyToken(builder);

        builder.HasIndex(p => p.NumeroInterno);

        builder.HasOne(p => p.Department)
               .WithMany(d => d.Users!)
               .HasForeignKey(p => p.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
