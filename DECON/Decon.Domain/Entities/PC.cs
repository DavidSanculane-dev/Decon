using Decon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Decon.Domain.Entities
{
    public class PC : AssetBase
    {

        // Excel: "Intune Name"
        [MaxLength(128)]
        public string? IntuneName { get; set; }

        // Excel: "CPU"
        [MaxLength(64)]
        public string? CPU { get; set; }

        // Excel: "Disk Space" (ex.: 500HDD, 512SSD, 1TB SSD)
        [MaxLength(32)]
        public string? Disk { get; set; }

        // Excel: "RAM" (ex.: 8GB, 16GB)
        [MaxLength(16)]
        public string? RAM { get; set; }

        // Excel: "Form factor" (Portatil, Desktop, AllinOne, WorkStation, Tablet)
        public FormFactorPC FormFactor { get; set; } = FormFactorPC.Portatil;

    }
}
