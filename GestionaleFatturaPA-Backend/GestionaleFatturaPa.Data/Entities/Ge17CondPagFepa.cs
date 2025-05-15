using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge17CondPagFepa
{
    public string Ge17Codice { get; set; } = null!;

    public string? Ge17Descrizione { get; set; }

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
