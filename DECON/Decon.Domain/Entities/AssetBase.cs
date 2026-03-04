using Decon.Domain.Common;
using Decon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public abstract class AssetBase :AuditableEntity
    {

        // Excel: "Nr. Imobilizado" / "Imobilizado"
        [MaxLength(64)]
        public string? Imobilizado { get; set; }

        // Excel: "Asset tag"
        [MaxLength(64)]
        public string? AssetTag { get; set; }

        // Excel: "Numero Interno"
        [MaxLength(64)]
        public string? NumeroInterno { get; set; }

        // Excel: "Nome" / "Nome Completo" / "Equipamento Partilhado"
        [MaxLength(256)]
        public string? Nome { get; set; }

        // Excel: "CC (SAP/RH)" / "CC (SAP)" / "CC (Protoc.)"
        [MaxLength(64)]
        public string? CentroCusto { get; set; }

        // Excel: "Marca"
        [MaxLength(64)]
        [Required]
        public string Marca { get; set; } = string.Empty;

        // Excel: "S. Number" / "Nº de Serie"
        [MaxLength(128)]
        public string? NumeroSerie { get; set; }

        // Excel: "Modelo"
        [MaxLength(128)]
        public string? Modelo { get; set; }

        // Excel: "Estado"  (Em uso, Avariado, Retirado, Em Stock, Não encontrado, Danificado)
        [Required]
        public EstadoEquipamento Estado { get; set; } = EstadoEquipamento.EmUso;

        // Excel: "Nota"
        [MaxLength(1024)]
        public string? Nota { get; set; }

    }
}
