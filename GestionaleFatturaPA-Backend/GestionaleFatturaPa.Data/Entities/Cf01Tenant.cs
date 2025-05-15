using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf01Tenant
{
    public Guid Cf01Tenant1 { get; set; }

    public Guid? Cf01TenantCf01 { get; set; }

    public bool? Cf01Deleted { get; set; }

    public DateTime? Cf01Datarinnovo { get; set; }

    public string? Cf01Nome { get; set; }

    public virtual An01Dittum? An01Dittum { get; set; }

    public virtual ICollection<An02Anagrafica> An02Anagraficas { get; set; } = new List<An02Anagrafica>();

    public virtual ICollection<An03Articolo> An03Articolos { get; set; } = new List<An03Articolo>();

    public virtual Cf01Tenant? Cf01TenantCf01Navigation { get; set; }

    public virtual ICollection<Cf02Utente> Cf02Utentes { get; set; } = new List<Cf02Utente>();

    public virtual ICollection<Cf03ParametriConf> Cf03ParametriConfs { get; set; } = new List<Cf03ParametriConf>();

    public virtual ICollection<Cf04Conto> Cf04Contos { get; set; } = new List<Cf04Conto>();

    public virtual ICollection<Cf05Pagamento> Cf05Pagamentos { get; set; } = new List<Cf05Pagamento>();

    public virtual ICollection<Cf06ClassArticolo> Cf06ClassArticolos { get; set; } = new List<Cf06ClassArticolo>();

    public virtual ICollection<Cf07Numerazione> Cf07Numeraziones { get; set; } = new List<Cf07Numerazione>();

    public virtual Cf08Smtp? Cf08Smtp { get; set; }

    public virtual ICollection<Cf08Sollecito> Cf08Sollecitos { get; set; } = new List<Cf08Sollecito>();

    public virtual ICollection<Cg01PrimaNotum> Cg01PrimaNota { get; set; } = new List<Cg01PrimaNotum>();

    public virtual ICollection<Cg02F24> Cg02F24s { get; set; } = new List<Cg02F24>();

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentos { get; set; } = new List<Do01TestataDocumento>();

    public virtual ICollection<Cf01Tenant> InverseCf01TenantCf01Navigation { get; set; } = new List<Cf01Tenant>();
}
