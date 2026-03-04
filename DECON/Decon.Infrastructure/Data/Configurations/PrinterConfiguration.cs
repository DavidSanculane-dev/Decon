using Decon.Domain.Entities;
using Decon.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Configurations;

public class PrinterConfiguration : AssetConfigurationBase<Printer>
{
    public override void Configure(EntityTypeBuilder<Printer> builder)
    {
        base.Configure(builder);

        builder.ToTable("printers");

        builder.Property(p => p.FormFactor)
               .HasConversion<string>()
               .HasMaxLength(32);
    }
}
