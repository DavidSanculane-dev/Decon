using Decon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decon.Domain.Entities
{
    public class Printer : AssetBase
    {
        
      // Excel: "Form factor" (MFP Empresarial, Plotter, MFP Desktop)
      public FormFactorPrinter FormFactor { get; set; } = FormFactorPrinter.MFPEmpresarial;

    }
}
