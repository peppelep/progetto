using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cg02F24
{
    public Guid Cg02TenantCf01 { get; set; }

    public Guid Cg02Keyf24 { get; set; }

    public bool? Cg02Deleted { get; set; }

    public DateTime? Cg02Data { get; set; }

    public string? Cg02Descrizione { get; set; }

    public decimal? Cg02Uscite { get; set; }

    public string? Cg02Stato { get; set; }

    public Guid? Cg02ContoCf04 { get; set; }

    public virtual Cf04Conto? Cf04Conto { get; set; }

    public virtual Cf01Tenant Cg02TenantCf01Navigation { get; set; } = null!;
}
