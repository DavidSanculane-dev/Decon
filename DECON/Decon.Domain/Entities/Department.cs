using Decon.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class Department : AuditableEntity
    {

        [Required]
        [MaxLength(64)]
        public string Codigo { get; set; } = string.Empty; // Ex.: 10159, 30159

        [MaxLength(256)]
        public string? Nome { get; set; }

        public ICollection<User>? Users { get; set; }

    }
}
