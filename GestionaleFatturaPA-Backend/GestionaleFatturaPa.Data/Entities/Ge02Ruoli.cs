using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge02Ruoli
{
    public Guid Ge02Ruolo { get; set; }

    public string Ge02Descrizione { get; set; } = null!;

    public string? Ge02Note { get; set; }

    public int? Ge02Gerarchia { get; set; }

    public virtual ICollection<Cf02Utente> Cf02Utentes { get; set; } = new List<Cf02Utente>();
}
