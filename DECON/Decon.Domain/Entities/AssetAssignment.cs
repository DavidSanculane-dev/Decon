using Decon.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class AssetAssignment : AuditableEntity
    {

        [Required]
        public int AssetId { get; set; }

        // O Asset pode ser PC, Monitor, Impressora
        public string AssetType { get; set; } = string.Empty; // "PC", "Monitor", "Printer"

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public DateTime DataAtribuicao { get; set; } = DateTime.UtcNow;

        public DateTime? DataDevolucao { get; set; }

        [MaxLength(512)]
        public string? Observacoes { get; set; }

    }
}
