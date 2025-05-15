using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do20Castellettoiva
{
    public Guid Do20TenantCf01 { get; set; }

    public Guid Do20Keydoc { get; set; }

    public int Do20CodiceivaGe03 { get; set; }

    public string? Do20Esigibilita { get; set; }

    public decimal? Do20Perciva { get; set; }

    public decimal? Do20Imponibile { get; set; }

    public decimal? Do20Imposta { get; set; }

    public string? Do20RiferimentoNormativo { get; set; }

    public virtual Do01TestataDocumento Do01TestataDocumento { get; set; } = null!;

    public virtual Ge03Iva Do20CodiceivaGe03Navigation { get; set; } = null!;
}
