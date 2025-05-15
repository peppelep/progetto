using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do05AltridatiFepa
{
    /// <summary>
    /// ZERO SE LEGATA ALLA TESTATA N RIGA SE LEGATO ALLA TABELLA RIGA
    /// </summary>
    public Guid Do05TenantCf01 { get; set; }

    public Guid Do05KeydocDo01 { get; set; }

    public Guid Do05KeyaltridatiGe16 { get; set; }

    public int Do05Numitem { get; set; }

    public int Do05Numrigadoc { get; set; }

    public string? Do05Valore { get; set; }

    public virtual Do01TestataDocumento Do01TestataDocumento { get; set; } = null!;
}
