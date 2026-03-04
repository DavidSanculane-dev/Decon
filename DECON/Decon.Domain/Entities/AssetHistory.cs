using Decon.Domain.Common;
using Decon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class AssetHistory : AuditableEntity
    {

        [Required]
        public int AssetId { get; set; }

        public string AssetType { get; set; } = string.Empty;

        public EstadoEquipamento EstadoAnterior { get; set; }
        public EstadoEquipamento EstadoNovo { get; set; }

        [MaxLength(256)]
        public string? AlteradoPor { get; set; }

        [MaxLength(1024)]
        public string? Observacoes { get; set; }

    }
}
