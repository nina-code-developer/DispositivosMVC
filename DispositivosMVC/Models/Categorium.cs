using System;
using System.Collections.Generic;

namespace DispositivosMVC.Models;

public partial class Categorium
{
    public int IdCt { get; set; }

    public string DescripcionCt { get; set; } = null!;

    public bool? EstadoCt { get; set; }

    public virtual ICollection<DispositivoPc> DispositivoPcs { get; set; } = new List<DispositivoPc>();
}
