using System;
using System.Collections.Generic;
using System.Text;
using Decon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Decon.Domain.Enums;
using Decon.Infrastructure.Data.Extensions;

namespace Decon.Infrastructure.Data.Configurations
{
    public abstract class AssetConfigurationBase<TAsset> : IEntityTypeConfiguration<TAsset> where TAsset : AssetBase
    {

        public virtual void Configure(EntityTypeBuilder<TAsset> builder)
        {
            builder.Property(p => p.Imobilizado).HasMaxLength(64);
            builder.Property(p => p.AssetTag).HasMaxLength(64);
            builder.Property(p => p.NumeroInterno).HasMaxLength(64);
            builder.Property(p => p.Nome).HasMaxLength(256);
            builder.Property(p => p.CentroCusto).HasMaxLength(64);
            builder.Property(p => p.Marca).HasMaxLength(64).IsRequired();
            builder.Property(p => p.NumeroSerie).HasMaxLength(128);
            builder.Property(p => p.Modelo).HasMaxLength(128);
            builder.Property(p => p.Nota).HasMaxLength(1024);

            // Enums como string (legível e seguro para relatórios)
            builder.Property(p => p.Estado)
                   .HasConversion<string>()
                   .HasMaxLength(32)
                   .HasDefaultValue(EstadoEquipamento.EmUso);


            // Concurrency token com xmin do PostgreSQL
            Decon.Infrastructure.Data.Extensions.ConcurrencyExtensions.UseXminAsConcurrencyToken(builder);


            // Índices úteis
            builder.HasIndex(p => p.AssetTag);
            builder.HasIndex(p => p.NumeroSerie);
            builder.HasIndex(p => new { p.Marca, p.Modelo });
        }


    }
}
