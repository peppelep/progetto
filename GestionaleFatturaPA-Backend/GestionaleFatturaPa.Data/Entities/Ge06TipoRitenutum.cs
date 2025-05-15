using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge06TipoRitenutum
{
    public string Ge06TipoRitenuta { get; set; } = null!;

    public string? Ge06Descrizione { get; set; }

    public virtual ICollection<An01Dittum> An01Ditta { get; set; } = new List<An01Dittum>();
}
