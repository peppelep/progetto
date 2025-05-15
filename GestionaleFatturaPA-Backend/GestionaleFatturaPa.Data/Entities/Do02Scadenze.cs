using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do02Scadenze
{
    public Guid Do02TenantCf01 { get; set; }

    public Guid Do02Keydoc { get; set; }

    public Guid Do02Keyscad { get; set; }

    public bool? Do02Deleted { get; set; }

    public DateTime? Do02Datascadenza { get; set; }

    public int? Do02Giorniscadenza { get; set; }

    public int? Do02Stato { get; set; }

    public string? Do02Tipo { get; set; }

    public decimal? Do02Importo { get; set; }

    public virtual Do01TestataDocumento Do01TestataDocumento { get; set; } = null!;
}
