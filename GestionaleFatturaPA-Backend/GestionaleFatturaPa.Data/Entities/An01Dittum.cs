using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class An01Dittum
{
    public Guid An01TenantCf01 { get; set; }

    public bool An01Deleted { get; set; }

    public string? An01Partitaiva { get; set; }

    public string? An01CodiceFiscale { get; set; }

    public string? An01IscrittoAlbo { get; set; }

    public short? An01TipoDitta { get; set; }

    public short? An01Forfettario { get; set; }

    public short? An01TipoForfettario { get; set; }

    public short? An01CoefficienteRedditivita { get; set; }

    public string? An01FatturaMedici { get; set; }

    public string? An01Albo { get; set; }

    public string? An01ProvinciaAlboGe08 { get; set; }

    public string? An01NumeroIscrizioneAlbo { get; set; }

    public DateTime? An01DataIscrizioneAlbo { get; set; }

    public string? An01Nome { get; set; }

    public string? An01Cognome { get; set; }

    public string? An01Ragsoc { get; set; }

    public string? An01Sottotitolo1 { get; set; }

    public string? An01Sottotitolo2 { get; set; }

    public string? An01IscrittoRea { get; set; }

    public string? An01UfficioReaGe08 { get; set; }

    public string? An01NumeroRea { get; set; }

    public decimal? An01CapitaleSociale { get; set; }

    public string? An01SocioUnico { get; set; }

    public string? An01StatoLiquidazione { get; set; }

    public string? An01RegimeFiscaleGe04 { get; set; }

    public int? An01CodiceivaGe03 { get; set; }

    public string? An01Ivaagricola { get; set; }

    public string? An01UtenteNotificheCf02 { get; set; }

    public string? An01Iban { get; set; }

    public string? An01EsigibilitaIva { get; set; }

    public string? An01Cassa01Ge05 { get; set; }

    public string? An01Cassa01ConRitenuta { get; set; }

    public decimal? An01RitenutaCassa01 { get; set; }

    public int? An01Codiceivacassa01Ge03 { get; set; }

    public string? An01Cassa02Ge05 { get; set; }

    public string? An01Cassa02ConRitenuta { get; set; }

    public decimal? An01RitenutaCassa02 { get; set; }

    public int? An01Codiceivacassa02Ge03 { get; set; }

    public string? An01TipoRitenutaGe06 { get; set; }

    public string? An01CausPagRitenutaGe07 { get; set; }

    public decimal? An01PercRitenuta { get; set; }

    public string? An01RivalsaInps { get; set; }

    public decimal? An01PercentualeRivalsaInps { get; set; }

    public int? An01ComuneGe01 { get; set; }

    public string? An01Indirizzo { get; set; }

    public string? An01NumeroCivico { get; set; }

    public string? An01CapDiverso { get; set; }

    public string? An01NoteIndirizzo { get; set; }

    public string? An01NomeContatto { get; set; }

    public string? An01EmailContatto { get; set; }

    public string? An01TelefonoContatto { get; set; }

    public string? An01NoteContatto { get; set; }

    public string? An01Sitoweb { get; set; }

    public string? An01EmailFattura { get; set; }

    public string? An01Enasarco { get; set; }

    public decimal? An01PercEnasarco { get; set; }

    public string? An01RitenutaEnasarco { get; set; }

    public string? An01TipologiaFatturaPredefinita { get; set; }

    public decimal? An01PercContributi { get; set; }

    public byte[]? An01LogoBase641 { get; set; }

    public byte[]? An01LogoBase642 { get; set; }

    public string? An01UserCreateCf02 { get; set; }

    public DateTime? An01DataCreate { get; set; }

    public string? An01UserUpdateCf02 { get; set; }

    public DateTime? An01DataUpdate { get; set; }

    public virtual Ge05CassaProf? An01Cassa01Ge05Navigation { get; set; }

    public virtual Ge05CassaProf? An01Cassa02Ge05Navigation { get; set; }

    public virtual Ge07CausPagRitenutum? An01CausPagRitenutaGe07Navigation { get; set; }

    public virtual Ge03Iva? An01CodiceivaGe03Navigation { get; set; }

    public virtual Ge03Iva? An01Codiceivacassa01Ge03Navigation { get; set; }

    public virtual Ge03Iva? An01Codiceivacassa02Ge03Navigation { get; set; }

    public virtual Ge01Comuni? An01ComuneGe01Navigation { get; set; }

    public virtual Ge08Provincium? An01ProvinciaAlboGe08Navigation { get; set; }

    public virtual Ge04RegimeFiscale? An01RegimeFiscaleGe04Navigation { get; set; }

    public virtual Cf01Tenant An01TenantCf01Navigation { get; set; } = null!;

    public virtual Ge06TipoRitenutum? An01TipoRitenutaGe06Navigation { get; set; }

    public virtual Ge08Provincium? An01UfficioReaGe08Navigation { get; set; }

    public virtual Cf02Utente? Cf02Utente { get; set; }

    public virtual Cf02Utente? Cf02Utente1 { get; set; }

    public virtual Cf02Utente? Cf02UtenteNavigation { get; set; }
}
