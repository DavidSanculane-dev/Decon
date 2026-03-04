using System;
using System.Collections.Generic;
using System.Text;

namespace Decon.Domain.Common
{
    public abstract class BaseEntity
    {

        public int Id { get; set; }

        /// <summary>Token de concorrência otimista.</summary>
        public byte[]? RowVersion { get; set; }


    }


    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? AtualizadoEm { get; set; }
    }


}
