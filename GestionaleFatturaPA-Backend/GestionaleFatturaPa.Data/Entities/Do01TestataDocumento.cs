using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Do01TestataDocumento
{
    public Guid Do01TenantCf01 { get; set; }

    public Guid Do01Keydoc { get; set; }

    public bool? Do01Deleted { get; set; }

    public string? Do01Stato { get; set; }

    public string? Do01CliforAn02 { get; set; }

    public Guid? Do01AnagraficaAn02 { get; set; }

    public int Do01CausaleCg07 { get; set; }

    public Guid? Do11PagamentoCf05 { get; set; }

    public int Do01AnnoCg07 { get; set; }

    public string? Do01SerieCg07 { get; set; }

    public DateTime? Do01Data { get; set; }

    public int? Do01Numero { get; set; }

    public string? Do01LinguaGe12 { get; set; }

    public string? Do01ValutaGe11 { get; set; }

    public string? Do01TassoCambio { get; set; }

    public string? Do01OggettoVis { get; set; }

    public string? Do01OggettoNas { get; set; }

    public string? Do01CentroCosto { get; set; }

    public decimal? Do01Primacassa { get; set; }

    public decimal? Do01PercimpPrimacassa { get; set; }

    public decimal? Do01Secondacassa { get; set; }

    public decimal? Do01PercimpSecondacassa { get; set; }

    public decimal? Do01RivalsaIva { get; set; }

    public decimal? Do01PercRivalsa { get; set; }

    public decimal? Do01Primaritenuta { get; set; }

    public decimal? Do01PercimpPrimaritenuta { get; set; }

    public decimal? Do01Secondaritenuta { get; set; }

    public decimal? Do01PercimpSecondaritenuta { get; set; }

    public string? Do01ModelloGe13 { get; set; }

    public int? Do01MargineVer { get; set; }

    public int? Do01MargineOrz { get; set; }

    public decimal? Do01Imponibile { get; set; }

    public decimal? Do01Imposta { get; set; }

    public decimal? Do01Totale { get; set; }

    public string? Do01Notedoc { get; set; }

    public int? Do01Mostratot { get; set; }

    public string? Do01SoggettoEmittente { get; set; }

    public string? Do01Targa { get; set; }

    public string? Do01TipodocFepaGe18 { get; set; }

    public bool? Do01Pa { get; set; }

    public string? Do01FeCodicedestinatario { get; set; }

    public string? Do01FePecdestinatario { get; set; }

    public string? Do01CondpagGe17 { get; set; }

    public string? Do01UserCreateCf02 { get; set; }

    public DateTime? Do01DataCreate { get; set; }

    public string? Do01UserUpdateCf02 { get; set; }

    public DateTime? Do01DataUpdate { get; set; }

    public virtual Cf02Utente? Cf02Utente { get; set; }

    public virtual Cf02Utente? Cf02UtenteNavigation { get; set; }

    public virtual Cf05Pagamento? Cf05Pagamento { get; set; }

    public virtual Cf07Numerazione? Cf07Numerazione { get; set; }

    public virtual Ge10CauDocumento Do01CausaleCg07Navigation { get; set; } = null!;

    public virtual Ge17CondPagFepa? Do01CondpagGe17Navigation { get; set; }

    public virtual Ge12Lingua? Do01LinguaGe12Navigation { get; set; }

    public virtual Ge13ModelloStampa? Do01ModelloGe13Navigation { get; set; }

    public virtual Cf01Tenant Do01TenantCf01Navigation { get; set; } = null!;

    public virtual Ge18TipoDocFepa? Do01TipodocFepaGe18Navigation { get; set; }

    public virtual Ge11Valutum? Do01ValutaGe11Navigation { get; set; }

    public virtual ICollection<Do02Scadenze> Do02Scadenzes { get; set; } = new List<Do02Scadenze>();

    public virtual ICollection<Do03DocorigineFepa> Do03DocorigineFepas { get; set; } = new List<Do03DocorigineFepa>();

    public virtual ICollection<Do04PagamentoFepa> Do04PagamentoFepas { get; set; } = new List<Do04PagamentoFepa>();

    public virtual ICollection<Do05AltridatiFepa> Do05AltridatiFepas { get; set; } = new List<Do05AltridatiFepa>();

    public virtual ICollection<Do10CorpoDocumento> Do10CorpoDocumentos { get; set; } = new List<Do10CorpoDocumento>();

    public virtual ICollection<Do20Castellettoiva> Do20Castellettoivas { get; set; } = new List<Do20Castellettoiva>();
}
