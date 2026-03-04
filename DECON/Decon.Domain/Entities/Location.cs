using Decon.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class Location : AuditableEntity
    {

        [Required]
        [MaxLength(128)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(256)]
        public string? Descricao { get; set; }

        public ICollection<AssetAssignment>? Ativos { get; set; }

    }
}
