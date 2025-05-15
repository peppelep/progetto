using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge18TipoDocFepa
{
    public string Ge18Codice { get; set; } = null!;

    public string Ge18Descrizione { get; set; } = null!;

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
