using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge10CauDocumento
{
    public int Ge10Causale { get; set; }

    public string? Ge10Nome { get; set; }

    public string? Ge10TipoClifor { get; set; }

    public int? Ge10Documento { get; set; }

    public string? Ge10FepaTipodocumento { get; set; }

    public virtual ICollection<Cf07Numerazione> Cf07Numeraziones { get; set; } = new List<Cf07Numerazione>();

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
