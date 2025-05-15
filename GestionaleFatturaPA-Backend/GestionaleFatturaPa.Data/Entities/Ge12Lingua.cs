using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge12Lingua
{
    public string Ge12Lingua1 { get; set; } = null!;

    public string? Ge12Descrizione { get; set; }

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
