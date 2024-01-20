using System;
using System.Collections.Generic;

namespace DispositivosMVC.Models;

public partial class Fabricante
{
    public int IdFb { get; set; }

    public string DescripcionFb { get; set; } = null!;

    public bool? EstadoFb { get; set; }

    public virtual ICollection<DispositivoPc> DispositivoPcs { get; set; } = new List<DispositivoPc>();
}
