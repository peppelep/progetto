using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf02Utente
{
    public Guid Cf02TenantCf01 { get; set; }

    public string Cf02Utente1 { get; set; } = null!;

    public Guid? Cf02RuoloGe02 { get; set; }

    public string? Cf02Password { get; set; }

    public string? Cf02Email { get; set; }

    public string? Cf02Telefono { get; set; }

    public bool? Cf02Fornitori { get; set; }

    public bool? Cf02Clienti { get; set; }

    public bool? Cf02Primanota { get; set; }

    public virtual ICollection<An01Dittum> An01DittumCf02Utente1s { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An01Dittum> An01DittumCf02UtenteNavigations { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An01Dittum> An01DittumCf02Utentes { get; set; } = new List<An01Dittum>();

    public virtual ICollection<An02Anagrafica> An02AnagraficaCf02UtenteNavigations { get; set; } = new List<An02Anagrafica>();

    public virtual ICollection<An02Anagrafica> An02AnagraficaCf02Utentes { get; set; } = new List<An02Anagrafica>();

    public virtual ICollection<An03Articolo> An03ArticoloCf02UtenteNavigations { get; set; } = new List<An03Articolo>();

    public virtual ICollection<An03Articolo> An03ArticoloCf02Utentes { get; set; } = new List<An03Articolo>();

    public virtual Ge02Ruoli? Cf02RuoloGe02Navigation { get; set; }

    public virtual Cf01Tenant Cf02TenantCf01Navigation { get; set; } = null!;

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentoCf02UtenteNavigations { get; set; } = new List<Do01TestataDocumento>();

    public virtual ICollection<Do01TestataDocumento> Do01TestataDocumentoCf02Utentes { get; set; } = new List<Do01TestataDocumento>();
}
