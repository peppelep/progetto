using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf05Pagamento
{
    public Guid Cf05Tenant { get; set; }

    public Guid Cf05Pagamento1 { get; set; }

    public string? Cf05Nome { get; set; }

    public string? Cf05Predefinito { get; set; }

    public string? Cf05Tipologia { get; set; }

    public Guid? Cf05ContoCf04 { get; set; }

    public string? Cf05Descrizione1 { get; set; }

    public string? Cf05Valore1 { get; set; }

    public string? Cf05Descrizione2 { get; set; }

    public string? Cf05Valore2 { get; set; }

    public string? Cf05Descrizione3 { get; set; }

    public string? Cf05Valore3 { get; set; }

    public string? Cf05Descrizione4 { get; set; }

    public string? Cf05Valore4 { get; set; }

    public virtual ICollection<An02Anagrafica> An02Anagraficas { get; set; } = new List<An02Anagrafica>();

    public virtual Cf01Tenant Cf05TenantNavigation { get; set; } = null!;

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();
}
