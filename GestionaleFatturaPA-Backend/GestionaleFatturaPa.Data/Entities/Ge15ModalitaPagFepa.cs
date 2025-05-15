using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Ge15ModalitaPagFepa
{
    public string Ge15Codice { get; set; } = null!;

    public string? Ge15Descrizione { get; set; }

    public virtual ICollection<Do04PagamentoFepa> Do04PagamentoFepas { get; set; } = new List<Do04PagamentoFepa>();
}
