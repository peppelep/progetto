using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge08Provincium
{
    public string Ge08Provincia { get; set; } = null!;

    public string? Ge08Nome { get; set; }

    public virtual ICollection<An01Dittum> An01DittumAn01ProvinciaAlboGe08Navigations { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An01Dittum> An01DittumAn01UfficioReaGe08Navigations { get; set; } = new List<An01Dittum>();
}
