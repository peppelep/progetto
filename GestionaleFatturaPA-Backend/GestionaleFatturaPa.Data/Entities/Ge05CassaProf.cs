using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge05CassaProf
{
    public string Ge05Cassa { get; set; } = null!;

    public string Ge05Descrizione { get; set; } = null!;

    public virtual ICollection<An01Dittum> An01DittumAn01Cassa01Ge05Navigations { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An01Dittum> An01DittumAn01Cassa02Ge05Navigations { get; set; } = new List<An01Dittum>();
}
