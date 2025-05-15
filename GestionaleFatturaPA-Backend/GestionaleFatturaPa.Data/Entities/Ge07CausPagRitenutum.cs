using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge07CausPagRitenutum
{
    public string Ge07CauPagRit { get; set; } = null!;

    public string? Ge07Descrizione { get; set; }

    public virtual ICollection<An01Dittum> An01Ditta { get; set; } = new List<An01Dittum>();
}
