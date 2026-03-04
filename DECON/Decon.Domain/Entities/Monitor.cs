using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class Monitor : AssetBase
    {

        // A aba "Monitor" tem também "Empresa ID" em alguns registos;
        // decidimos normalizar para "CentroCusto" na classe base.
        // Se precisares de "EmpresaId" em separado, adiciona aqui:
        [MaxLength(64)]
        public string? EmpresaId { get; set; }


    }
}
