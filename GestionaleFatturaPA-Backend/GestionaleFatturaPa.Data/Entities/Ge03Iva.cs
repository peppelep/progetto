using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge03Iva
{
    public int Ge03CodiceIva { get; set; }

    public string Ge03Descrizione { get; set; } = null!;

    public decimal Ge03Iva1 { get; set; }

    public decimal Ge03PercIndetraibilita { get; set; }

    public string Ge03CodiceFatturapa { get; set; } = null!;

    public virtual ICollection<An01Dittum> An01DittumAn01CodiceivaGe03Navigations { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An01Dittum> An01DittumAn01Codiceivacassa01Ge03Navigations { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An01Dittum> An01DittumAn01Codiceivacassa02Ge03Navigations { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An02Anagrafica> An02Anagraficas { get; set; } = new List<An02Anagrafica>();

    public virtual ICollection<An03Articolo> An03Articolos { get; set; } = new List<An03Articolo>();

    public virtual ICollection<Do10CorpoDocumento> Do10CorpoDocumentos { get; set; } = new List<Do10CorpoDocumento>();

    public virtual ICollection<Do20Castellettoiva> Do20Castellettoivas { get; set; } = new List<Do20Castellettoiva>();
}
