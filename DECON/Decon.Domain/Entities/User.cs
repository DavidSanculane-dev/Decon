using Decon.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class User : AuditableEntity
    {

        [Required]
        [MaxLength(256)]
        public string NomeCompleto { get; set; } = string.Empty;

        [MaxLength(64)]
        public string? NumeroInterno { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<AssetAssignment>? Ativos { get; set; }

    }
}
