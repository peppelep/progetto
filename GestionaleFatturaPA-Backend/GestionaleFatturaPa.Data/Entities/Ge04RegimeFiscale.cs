using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge04RegimeFiscale
{
    public string Ge04RegimeFiscale1 { get; set; } = null!;

    public string Ge04Descrizione { get; set; } = null!;

    public virtual ICollection<An01Dittum> An01Ditta { get; set; } = new List<An01Dittum>();
}
