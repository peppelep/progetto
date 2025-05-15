using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do04PagamentoFepa
{
    public Guid Do04TenantCf01 { get; set; }

    public Guid Do04Keydoc { get; set; }

    public int Do04Rigaid { get; set; }

    public string? Do04PagFepaGe15 { get; set; }

    public decimal? Do04Importo { get; set; }

    public DateOnly? Do04Datarifpag { get; set; }

    public DateOnly? Do04Datascadenza { get; set; }

    public string? Do04Iban { get; set; }

    public string? Do04Banca { get; set; }

    public string? Do04Abi { get; set; }

    public string? Do04Cab { get; set; }

    public virtual Do01TestataDocumento Do01TestataDocumento { get; set; } = null!;

    public virtual Ge15ModalitaPagFepa? Do04PagFepaGe15Navigation { get; set; }
}
