using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class An03Articolo
{
    public Guid An03TenantCf01 { get; set; }

    public Guid An03Articolo1 { get; set; }

    public string? An03Codicearticolo { get; set; }

    public bool? An03Deleted { get; set; }

    public string? An03Descrizione { get; set; }

    public string? An03Note { get; set; }

    public Guid? An03ClassificazioneCf06 { get; set; }

    public string? An03DescrizioneEstesa { get; set; }

    public int? An03IvaGe03 { get; set; }

    public string? An03TipoPrezzo { get; set; }

    public decimal? An03Prezzo { get; set; }

    public decimal? An03Costo { get; set; }

    public string? An03AbilitaMagazzino { get; set; }

    public decimal? An03GiacenzaIniziale { get; set; }

    public decimal? An03GiacenzaAttuale { get; set; }

    public string? An03UserCreateCf02 { get; set; }

    public DateTime? An03DataCreate { get; set; }

    public string? An03UserUpdateCf02 { get; set; }

    public DateTime? An03DataUpdate { get; set; }

    public string? An03Um { get; set; }

    public virtual Ge03Iva? An03IvaGe03Navigation { get; set; }

    public virtual Cf01Tenant An03TenantCf01Navigation { get; set; } = null!;

    public virtual Cf02Utente? Cf02Utente { get; set; }

    public virtual Cf02Utente? Cf02UtenteNavigation { get; set; }

    public virtual Cf06ClassArticolo? Cf06ClassArticolo { get; set; }

    public virtual ICollection<Do10CorpoDocumento> Do10CorpoDocumentos { get; set; } = new List<Do10CorpoDocumento>();
}
