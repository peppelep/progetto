using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf06ClassArticolo
{
    public Guid Cf06TenantCf01 { get; set; }

    public Guid Cf06Classificazione { get; set; }

    public string Cf06Nome { get; set; } = null!;

    public virtual ICollection<An03Articolo> An03Articolos { get; set; } = new List<An03Articolo>();

    public virtual Cf01Tenant Cf06TenantCf01Navigation { get; set; } = null!;
}
