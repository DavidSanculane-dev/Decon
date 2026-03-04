using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Decon.Infrastructure.Data.Extensions;

public static class ConcurrencyExtensions
{
    /// <summary>
    /// Configura o campo xmin do PostgreSQL como token de concorrência.
    /// </summary>
    public static void UseXminAsConcurrencyToken<T>(this EntityTypeBuilder<T> builder) where T : class
    {
        builder.Property<uint>("xmin")
            .IsRowVersion()
            .HasColumnName("xmin");
    }
}