using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do03DocorigineFepa
{
    public Guid Do03TenantCf01 { get; set; }

    public Guid Do03Keydoc { get; set; }

    public int Do03Tipo { get; set; }

    public int Do03Rigaid { get; set; }

    public string? Do03Iddocumento { get; set; }

    public DateOnly? Do03Data { get; set; }

    public string? Do03Numitem { get; set; }

    public string? Do03Commessa { get; set; }

    public string? Do03Cup { get; set; }

    public string? Do03Cig { get; set; }

    public virtual Do01TestataDocumento Do01TestataDocumento { get; set; } = null!;
}
