using System;
using System.Collections.Generic;

namespace DispositivosMVC.Models;

public partial class DispositivoPc
{
    public int IdDpc { get; set; }

    public string SerieDpc { get; set; } = null!;

    public string DescripcionDpc { get; set; } = null!;

    public decimal PrecioDpc { get; set; }

    public bool? EstadoGarantiaDpc { get; set; }

    public int? IdFb { get; set; }

    public int? IdCt { get; set; }

    public virtual Categorium? IdCtNavigation { get; set; }

    public virtual Fabricante? IdFbNavigation { get; set; }
}
