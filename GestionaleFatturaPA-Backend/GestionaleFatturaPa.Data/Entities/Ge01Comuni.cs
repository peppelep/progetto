using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge01Comuni
{
    public int Ge01Comune { get; set; }

    public string Ge01Nome { get; set; } = null!;

    public string Ge01Codiceistat { get; set; } = null!;

    public string Ge01Provincia { get; set; } = null!;

    public string Ge01Regione { get; set; } = null!;

    public string Ge01Cap { get; set; } = null!;

    public string Ge01Stato { get; set; } = null!;

    public string Ge02CodiceStato { get; set; } = null!;

    public virtual ICollection<An01Dittum> An01Ditta { get; set; } = new List<An01Dittum>();
}
