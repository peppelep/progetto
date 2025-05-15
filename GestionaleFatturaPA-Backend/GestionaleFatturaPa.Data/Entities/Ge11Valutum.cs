using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge11Valutum
{
    public string Ge11Valuta { get; set; } = null!;

    public decimal? Ge11TassoCambio { get; set; }

    public DateTime? Ge11DataUltimoAggiornamento { get; set; }

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
