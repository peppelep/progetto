using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge13ModelloStampa
{
    public string Ge13Modello { get; set; } = null!;

    public string? Ge13Descrizione { get; set; }

    public int? Ge13MargOrizMm { get; set; }

    public int? Ge13MargVertMm { get; set; }

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
