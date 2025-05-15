using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cg01PrimaNotum
{
    public Guid Cg01TenantCf01 { get; set; }

    public Guid Cg01Keypn { get; set; }

    public DateTime? Cg01Data { get; set; }

    public bool? Cg01Deleted { get; set; }

    public string? Cg01CliforAn02 { get; set; }

    public Guid? Cg01AnagraficaAn02 { get; set; }

    public Guid? Cg01ContoUscitaCf04 { get; set; }

    public Guid? Cg01ContoEntrataCf04 { get; set; }

    public string? Cg01Note { get; set; }

    public decimal? Cg01Entrate { get; set; }

    public decimal? Cg01Uscite { get; set; }

    public virtual An02Anagrafica? An02Anagrafica { get; set; }

    public virtual Cf04Conto? Cf04Conto { get; set; }

    public virtual Cf04Conto? Cf04ContoNavigation { get; set; }

    public virtual Cf01Tenant Cg01TenantCf01Navigation { get; set; } = null!;
}
