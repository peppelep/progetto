using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf07Numerazione
{
    public Guid Cf07TenantCf01 { get; set; }

    public int Cg07Anno { get; set; }

    public int Cg07CausaleGe10 { get; set; }

    public string Cf07Serie { get; set; } = null!;

    public int Cf07Numero { get; set; }

    public virtual Cf01Tenant Cf07TenantCf01Navigation { get; set; } = null!;

    public virtual Ge10CauDocumento Cg07CausaleGe10Navigation { get; set; } = null!;

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
