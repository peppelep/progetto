using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do10CorpoDocumento
{
    public Guid Do10TenantCf01 { get; set; }

    public Guid Do10Keydoc { get; set; }

    public int Do10Numriga { get; set; }

    public bool? Do10Deleted { get; set; }

    public string? Do01TipocessioneFepa { get; set; }

    public Guid? Do10ArticoloAn03 { get; set; }

    public string? Do10CodiceArticolo { get; set; }

    public string? Do10Descrizione { get; set; }

    public string? Do10Um { get; set; }

    public decimal? Do10Prznetto { get; set; }

    public decimal? Do10Przlordo { get; set; }

    public decimal? Do10Sc1 { get; set; }

    public int? Do10CodiceivaGe03 { get; set; }

    public decimal? Do10Perciva { get; set; }

    public decimal? Do10Perdetr { get; set; }

    public decimal? Do10Importo { get; set; }

    public string? Do10CatCostoRicavo { get; set; }

    public bool? Do10FlgNonimponibile { get; set; }

    public bool? Do10FlgRitenuteCassa { get; set; }

    public Guid? Do10KeydocoriginDo10 { get; set; }

    public int? Do10NumrigaoriginDo10 { get; set; }

    public virtual An03Articolo? An03Articolo { get; set; }

    public virtual Do01TestataDocumento Do01TestataDocumento { get; set; } = null!;

    public virtual Ge03Iva? Do10CodiceivaGe03Navigation { get; set; }

    public virtual Do10CorpoDocumento? Do10CorpoDocumentoNavigation { get; set; }

    public virtual ICollection<Do10CorpoDocumento> InverseDo10CorpoDocumentoNavigation { get; set; } = new List<Do10CorpoDocumento>();
}
