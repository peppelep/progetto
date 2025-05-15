using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf04Conto
{
    public Guid Cf04TenantCf01 { get; set; }

    public Guid Cf04Conto1 { get; set; }

    public string? Cf04Nome { get; set; }

    public string? Cf04Tipo { get; set; }

    public string? Cf04Iban { get; set; }

    public string? Cf04CodiceSia { get; set; }

    public virtual Cf01Tenant Cf04TenantCf01Navigation { get; set; } = null!;

    public virtual ICollection<Cg01PrimaNotum> Cg01PrimaNotumCf04ContoNavigations { get; set; } = new List<Cg01PrimaNotum>();

    public virtual ICollection<Cg01PrimaNotum> Cg01PrimaNotumCf04Contos { get; set; } = new List<Cg01PrimaNotum>();

    public virtual ICollection<Cg02F24> Cg02F24s { get; set; } = new List<Cg02F24>();
}
