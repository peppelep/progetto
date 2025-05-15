using System;
using System.Collections.Generic;
using GestionaleFatturaPa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestionaleFatturaPa.Data.Context;

public partial class GestionaleFatturaPaContext : DbContext
{
	private readonly IConfiguration _configuration;
	public GestionaleFatturaPaContext()
    {
    }

    public GestionaleFatturaPaContext(DbContextOptions<GestionaleFatturaPaContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<An01Dittum> An01Ditta { get; set; }

    public virtual DbSet<An02Anagrafica> An02Anagraficas { get; set; }

    public virtual DbSet<An03Articolo> An03Articolos { get; set; }

    public virtual DbSet<Cf01Tenant> Cf01Tenants { get; set; }

    public virtual DbSet<Cf02Utente> Cf02Utentes { get; set; }

    public virtual DbSet<Cf03ParametriConf> Cf03ParametriConfs { get; set; }

    public virtual DbSet<Cf04Conto> Cf04Contos { get; set; }

    public virtual DbSet<Cf05Pagamento> Cf05Pagamentos { get; set; }

    public virtual DbSet<Cf06ClassArticolo> Cf06ClassArticolos { get; set; }

    public virtual DbSet<Cf07Numerazione> Cf07Numeraziones { get; set; }

    public virtual DbSet<Cf08Smtp> Cf08Smtps { get; set; }

    public virtual DbSet<Cf08Sollecito> Cf08Sollecitos { get; set; }

    public virtual DbSet<Cg01PrimaNotum> Cg01PrimaNota { get; set; }

    public virtual DbSet<Cg02F24> Cg02F24s { get; set; }

    public virtual DbSet<Do01TestataDocumento> Do01TestataDocumentos { get; set; }

    public virtual DbSet<Do02Scadenze> Do02Scadenzes { get; set; }

    public virtual DbSet<Do03DocorigineFepa> Do03DocorigineFepas { get; set; }

    public virtual DbSet<Do04PagamentoFepa> Do04PagamentoFepas { get; set; }

    public virtual DbSet<Do05AltridatiFepa> Do05AltridatiFepas { get; set; }

    public virtual DbSet<Do10CorpoDocumento> Do10CorpoDocumentos { get; set; }

    public virtual DbSet<Do20Castellettoiva> Do20Castellettoivas { get; set; }

    public virtual DbSet<Ge01Comuni> Ge01Comunis { get; set; }

    public virtual DbSet<Ge02Ruoli> Ge02Ruolis { get; set; }

    public virtual DbSet<Ge03Iva> Ge03Ivas { get; set; }

    public virtual DbSet<Ge04RegimeFiscale> Ge04RegimeFiscales { get; set; }

    public virtual DbSet<Ge05CassaProf> Ge05CassaProfs { get; set; }

    public virtual DbSet<Ge06TipoRitenutum> Ge06TipoRitenuta { get; set; }

    public virtual DbSet<Ge07CausPagRitenutum> Ge07CausPagRitenuta { get; set; }

    public virtual DbSet<Ge08Provincium> Ge08Provincia { get; set; }

    public virtual DbSet<Ge09Stato> Ge09Statos { get; set; }

    public virtual DbSet<Ge10CauDocumento> Ge10CauDocumentos { get; set; }

    public virtual DbSet<Ge11Valutum> Ge11Valuta { get; set; }

    public virtual DbSet<Ge12Lingua> Ge12Linguas { get; set; }

    public virtual DbSet<Ge13ModelloStampa> Ge13ModelloStampas { get; set; }

    public virtual DbSet<Ge14Um> Ge14Ums { get; set; }

    public virtual DbSet<Ge15ModalitaPagFepa> Ge15ModalitaPagFepas { get; set; }

    public virtual DbSet<Ge16AltriDatiFepa> Ge16AltriDatiFepas { get; set; }

    public virtual DbSet<Ge17CondPagFepa> Ge17CondPagFepas { get; set; }

    public virtual DbSet<Ge18TipoDocFepa> Ge18TipoDocFepas { get; set; }

    public virtual DbSet<Ge19TipocessionePrestazione> Ge19TipocessionePrestaziones { get; set; }


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AutofiscoDb"));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<An01Dittum>(entity =>
        {
            entity.HasKey(e => e.An01TenantCf01);

            entity.ToTable("AN01_DITTA");

            entity.Property(e => e.An01TenantCf01)
                .ValueGeneratedNever()
                .HasColumnName("AN01_TENANT_CF01");
            entity.Property(e => e.An01Albo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_ALBO");
            entity.Property(e => e.An01CapDiverso)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_CAP_DIVERSO");
            entity.Property(e => e.An01CapitaleSociale)
                .HasColumnType("money")
                .HasColumnName("AN01_CAPITALE_SOCIALE");
            entity.Property(e => e.An01Cassa01ConRitenuta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_CASSA01_CON_RITENUTA");
            entity.Property(e => e.An01Cassa01Ge05)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN01_CASSA01_GE05");
            entity.Property(e => e.An01Cassa02ConRitenuta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_CASSA02_CON_RITENUTA");
            entity.Property(e => e.An01Cassa02Ge05)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN01_CASSA02_GE05");
            entity.Property(e => e.An01CausPagRitenutaGe07)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN01_CAUS_PAG_RITENUTA_GE07");
            entity.Property(e => e.An01CodiceFiscale)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("AN01_CODICE_FISCALE");
            entity.Property(e => e.An01CodiceivaGe03).HasColumnName("AN01_CODICEIVA_GE03");
            entity.Property(e => e.An01Codiceivacassa01Ge03).HasColumnName("AN01_CODICEIVACASSA01_GE03");
            entity.Property(e => e.An01Codiceivacassa02Ge03).HasColumnName("AN01_CODICEIVACASSA02_GE03");
            entity.Property(e => e.An01CoefficienteRedditivita).HasColumnName("AN01_COEFFICIENTE_REDDITIVITA");
            entity.Property(e => e.An01Cognome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_COGNOME");
            entity.Property(e => e.An01ComuneGe01).HasColumnName("AN01_COMUNE_GE01");
            entity.Property(e => e.An01DataCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("AN01_DATA_CREATE");
            entity.Property(e => e.An01DataIscrizioneAlbo)
                .HasColumnType("datetime")
                .HasColumnName("AN01_DATA_ISCRIZIONE_ALBO");
            entity.Property(e => e.An01DataUpdate)
                .HasColumnType("datetime")
                .HasColumnName("AN01_DATA_UPDATE");
            entity.Property(e => e.An01Deleted).HasColumnName("AN01_DELETED");
            entity.Property(e => e.An01EmailContatto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_EMAIL_CONTATTO");
            entity.Property(e => e.An01EmailFattura)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_EMAIL_FATTURA");
            entity.Property(e => e.An01Enasarco)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_ENASARCO");
            entity.Property(e => e.An01EsigibilitaIva)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_ESIGIBILITA_IVA");
            entity.Property(e => e.An01FatturaMedici)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_FATTURA_MEDICI");
            entity.Property(e => e.An01Forfettario).HasColumnName("AN01_FORFETTARIO");
            entity.Property(e => e.An01Iban)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN01_IBAN");
            entity.Property(e => e.An01Indirizzo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("AN01_INDIRIZZO");
            entity.Property(e => e.An01IscrittoAlbo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_ISCRITTO_ALBO");
            entity.Property(e => e.An01IscrittoRea)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_ISCRITTO_REA");
            entity.Property(e => e.An01Ivaagricola)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_IVAAGRICOLA");
            entity.Property(e => e.An01LogoBase641).HasColumnName("AN01_LOGO_BASE64_1");
            entity.Property(e => e.An01LogoBase642).HasColumnName("AN01_LOGO_BASE64_2");
            entity.Property(e => e.An01Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_NOME");
            entity.Property(e => e.An01NomeContatto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_NOME_CONTATTO");
            entity.Property(e => e.An01NoteContatto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_NOTE_CONTATTO");
            entity.Property(e => e.An01NoteIndirizzo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_NOTE_INDIRIZZO");
            entity.Property(e => e.An01NumeroCivico)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN01_NUMERO_CIVICO");
            entity.Property(e => e.An01NumeroIscrizioneAlbo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AN01_NUMERO_ISCRIZIONE_ALBO");
            entity.Property(e => e.An01NumeroRea)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_NUMERO_REA");
            entity.Property(e => e.An01Partitaiva)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("AN01_PARTITAIVA");
            entity.Property(e => e.An01PercContributi)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AN01_PERC_CONTRIBUTI");
            entity.Property(e => e.An01PercEnasarco)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AN01_PERC_ENASARCO");
            entity.Property(e => e.An01PercRitenuta)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AN01_PERC_RITENUTA");
            entity.Property(e => e.An01PercentualeRivalsaInps)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AN01_PERCENTUALE_RIVALSA_INPS");
            entity.Property(e => e.An01ProvinciaAlboGe08)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_PROVINCIA_ALBO_GE08");
            entity.Property(e => e.An01Ragsoc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_RAGSOC");
            entity.Property(e => e.An01RegimeFiscaleGe04)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN01_REGIME_FISCALE_GE04");
            entity.Property(e => e.An01RitenutaCassa01)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AN01_RITENUTA_CASSA01");
            entity.Property(e => e.An01RitenutaCassa02)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AN01_RITENUTA_CASSA02");
            entity.Property(e => e.An01RitenutaEnasarco)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("AN01_RITENUTA_ENASARCO");
            entity.Property(e => e.An01RivalsaInps)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_RIVALSA_INPS");
            entity.Property(e => e.An01Sitoweb)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN01_SITOWEB");
            entity.Property(e => e.An01SocioUnico)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_SOCIO_UNICO");
            entity.Property(e => e.An01Sottotitolo1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("AN01_SOTTOTITOLO_1");
            entity.Property(e => e.An01Sottotitolo2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("AN01_SOTTOTITOLO_2");
            entity.Property(e => e.An01StatoLiquidazione)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_STATO_LIQUIDAZIONE");
            entity.Property(e => e.An01TelefonoContatto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AN01_TELEFONO_CONTATTO");
            entity.Property(e => e.An01TipoDitta).HasColumnName("AN01_TIPO_DITTA");
            entity.Property(e => e.An01TipoForfettario).HasColumnName("AN01_TIPO_FORFETTARIO");
            entity.Property(e => e.An01TipoRitenutaGe06)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN01_TIPO_RITENUTA_GE06");
            entity.Property(e => e.An01TipologiaFatturaPredefinita)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("AN01_TIPOLOGIA_FATTURA_PREDEFINITA");
            entity.Property(e => e.An01UfficioReaGe08)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN01_UFFICIO_REA_GE08");
            entity.Property(e => e.An01UserCreateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN01_USER_CREATE_CF02");
            entity.Property(e => e.An01UserUpdateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN01_USER_UPDATE_CF02");
            entity.Property(e => e.An01UtenteNotificheCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN01_UTENTE_NOTIFICHE_CF02");

            entity.HasOne(d => d.An01Cassa01Ge05Navigation).WithMany(p => p.An01DittumAn01Cassa01Ge05Navigations)
                .HasForeignKey(d => d.An01Cassa01Ge05)
                .HasConstraintName("FK_AN01_CASSA01_GE05");

            entity.HasOne(d => d.An01Cassa02Ge05Navigation).WithMany(p => p.An01DittumAn01Cassa02Ge05Navigations)
                .HasForeignKey(d => d.An01Cassa02Ge05)
                .HasConstraintName("FK_AN01_CASSA02_GE05");

            entity.HasOne(d => d.An01CausPagRitenutaGe07Navigation).WithMany(p => p.An01Ditta)
                .HasForeignKey(d => d.An01CausPagRitenutaGe07)
                .HasConstraintName("FK_AN01_CAUS_PAG_RITENUTA_GE07");

            entity.HasOne(d => d.An01CodiceivaGe03Navigation).WithMany(p => p.An01DittumAn01CodiceivaGe03Navigations)
                .HasForeignKey(d => d.An01CodiceivaGe03)
                .HasConstraintName("FK_AN01_CODICEIVA_GE03");

            entity.HasOne(d => d.An01Codiceivacassa01Ge03Navigation).WithMany(p => p.An01DittumAn01Codiceivacassa01Ge03Navigations)
                .HasForeignKey(d => d.An01Codiceivacassa01Ge03)
                .HasConstraintName("FK_AN01_CODICEIVACASSA01_GE03");

            entity.HasOne(d => d.An01Codiceivacassa02Ge03Navigation).WithMany(p => p.An01DittumAn01Codiceivacassa02Ge03Navigations)
                .HasForeignKey(d => d.An01Codiceivacassa02Ge03)
                .HasConstraintName("FK_AN01_CODICEIVACASSA02_GE03");

            entity.HasOne(d => d.An01ComuneGe01Navigation).WithMany(p => p.An01Ditta)
                .HasForeignKey(d => d.An01ComuneGe01)
                .HasConstraintName("FK_AN01_COMUNE_GE01");

            entity.HasOne(d => d.An01ProvinciaAlboGe08Navigation).WithMany(p => p.An01DittumAn01ProvinciaAlboGe08Navigations)
                .HasForeignKey(d => d.An01ProvinciaAlboGe08)
                .HasConstraintName("FK_AN01_PROVINCIA_ALBO_GE08");

            entity.HasOne(d => d.An01RegimeFiscaleGe04Navigation).WithMany(p => p.An01Ditta)
                .HasForeignKey(d => d.An01RegimeFiscaleGe04)
                .HasConstraintName("FK_AN01_REGIME_FISCALE_GE04");

            entity.HasOne(d => d.An01TenantCf01Navigation).WithOne(p => p.An01Dittum)
                .HasForeignKey<An01Dittum>(d => d.An01TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AN01_CF01_TENANT");

            entity.HasOne(d => d.An01TipoRitenutaGe06Navigation).WithMany(p => p.An01Ditta)
                .HasForeignKey(d => d.An01TipoRitenutaGe06)
                .HasConstraintName("FK_AN01_TIPO_RITENUTA_GE06");

            entity.HasOne(d => d.An01UfficioReaGe08Navigation).WithMany(p => p.An01DittumAn01UfficioReaGe08Navigations)
                .HasForeignKey(d => d.An01UfficioReaGe08)
                .HasConstraintName("FK_AN01_UFFICIO_REA_GE08");

            entity.HasOne(d => d.Cf02Utente).WithMany(p => p.An01DittumCf02Utentes)
                .HasForeignKey(d => new { d.An01TenantCf01, d.An01UserCreateCf02 })
                .HasConstraintName("FK_AN01_USER_CREATE_CF02");

            entity.HasOne(d => d.Cf02UtenteNavigation).WithMany(p => p.An01DittumCf02UtenteNavigations)
                .HasForeignKey(d => new { d.An01TenantCf01, d.An01UserUpdateCf02 })
                .HasConstraintName("FK_AN01_USER_UPDATE_CF02");

            entity.HasOne(d => d.Cf02Utente1).WithMany(p => p.An01DittumCf02Utente1s)
                .HasForeignKey(d => new { d.An01TenantCf01, d.An01UtenteNotificheCf02 })
                .HasConstraintName("FK_AN01_UTENTE_NOTIFICHE_CF02");
        });

        modelBuilder.Entity<An02Anagrafica>(entity =>
        {
            entity.HasKey(e => new { e.An02TenantCf01, e.An02Clifor, e.An02Anagrafica1 });

            entity.ToTable("AN02_ANAGRAFICA");

            entity.Property(e => e.An02TenantCf01).HasColumnName("AN02_TENANT_CF01");
            entity.Property(e => e.An02Clifor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN02_CLIFOR");
            entity.Property(e => e.An02Anagrafica1).HasColumnName("AN02_ANAGRAFICA");
            entity.Property(e => e.An02Cap)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("AN02_CAP");
            entity.Property(e => e.An02CodiceInterno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN02_CODICE_INTERNO");
            entity.Property(e => e.An02Codicesdi)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("AN02_CODICESDI");
            entity.Property(e => e.An02CoiceFiscale)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("AN02_COICE_FISCALE");
            entity.Property(e => e.An02Comune)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN02_COMUNE");
            entity.Property(e => e.An02DataCreate)
                .HasColumnType("datetime")
                .HasColumnName("AN02_DATA_CREATE");
            entity.Property(e => e.An02DataLettera)
                .HasColumnType("datetime")
                .HasColumnName("AN02_DATA_LETTERA");
            entity.Property(e => e.An02DataUpdate)
                .HasColumnType("datetime")
                .HasColumnName("AN02_DATA_UPDATE");
            entity.Property(e => e.An02Deleted).HasColumnName("AN02_DELETED");
            entity.Property(e => e.An02GiorniPag).HasColumnName("AN02_GIORNI_PAG");
            entity.Property(e => e.An02Iban)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN02_IBAN");
            entity.Property(e => e.An02IndirizzoPec)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN02_INDIRIZZO_PEC");
            entity.Property(e => e.An02IndirizzoSpedizione)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("AN02_INDIRIZZO_SPEDIZIONE");
            entity.Property(e => e.An02IvapredefGe03).HasColumnName("AN02_IVAPREDEF_GE03");
            entity.Property(e => e.An02LetteraIntento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN02_LETTERA_INTENTO");
            entity.Property(e => e.An02Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("AN02_NOTE");
            entity.Property(e => e.An02NoteIndirizzo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("AN02_NOTE_INDIRIZZO");
            entity.Property(e => e.An02Numerolettera)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN02_NUMEROLETTERA");
            entity.Property(e => e.An02PagamentoCf05).HasColumnName("AN02_PAGAMENTO_CF05");
            entity.Property(e => e.An02Partitaiva)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AN02_PARTITAIVA");
            entity.Property(e => e.An02Periodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN02_PERIODO");
            entity.Property(e => e.An02Provincia)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("AN02_PROVINCIA");
            entity.Property(e => e.An02Ragsoc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AN02_RAGSOC");
            entity.Property(e => e.An02Referente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN02_REFERENTE");
            entity.Property(e => e.An02Sconto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AN02_SCONTO");
            entity.Property(e => e.An02Stato)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AN02_STATO");
            entity.Property(e => e.An02Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AN02_TELEFONO");
            entity.Property(e => e.An02Tipologia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN02_TIPOLOGIA");
            entity.Property(e => e.An02UserCreateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN02_USER_CREATE_CF02");
            entity.Property(e => e.An02UserUpdateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN02_USER_UPDATE_CF02");

            entity.HasOne(d => d.An02IvapredefGe03Navigation).WithMany(p => p.An02Anagraficas)
                .HasForeignKey(d => d.An02IvapredefGe03)
                .HasConstraintName("FK_AN02_IVAPREDEF_GE03");

            entity.HasOne(d => d.An02TenantCf01Navigation).WithMany(p => p.An02Anagraficas)
                .HasForeignKey(d => d.An02TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AN02_CF01_TENANT");

            entity.HasOne(d => d.Cf05Pagamento).WithMany(p => p.An02Anagraficas)
                .HasForeignKey(d => new { d.An02TenantCf01, d.An02PagamentoCf05 })
                .HasConstraintName("FK_AN02_PAGAMENTO_CG05");

            entity.HasOne(d => d.Cf02Utente).WithMany(p => p.An02AnagraficaCf02Utentes)
                .HasForeignKey(d => new { d.An02TenantCf01, d.An02UserCreateCf02 })
                .HasConstraintName("FK_AN02_USER_CREATE_CF02");

            entity.HasOne(d => d.Cf02UtenteNavigation).WithMany(p => p.An02AnagraficaCf02UtenteNavigations)
                .HasForeignKey(d => new { d.An02TenantCf01, d.An02UserUpdateCf02 })
                .HasConstraintName("FK_AN02_USER_UPDATE_CF02");
        });

        modelBuilder.Entity<An03Articolo>(entity =>
        {
            entity.HasKey(e => new { e.An03TenantCf01, e.An03Articolo1 });

            entity.ToTable("AN03_ARTICOLO");

            entity.Property(e => e.An03TenantCf01).HasColumnName("AN03_TENANT_CF01");
            entity.Property(e => e.An03Articolo1).HasColumnName("AN03_ARTICOLO");
            entity.Property(e => e.An03AbilitaMagazzino)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN03_ABILITA_MAGAZZINO");
            entity.Property(e => e.An03ClassificazioneCf06).HasColumnName("AN03_CLASSIFICAZIONE_CF06");
            entity.Property(e => e.An03Codicearticolo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("AN03_CODICEARTICOLO");
            entity.Property(e => e.An03Costo)
                .HasColumnType("money")
                .HasColumnName("AN03_COSTO");
            entity.Property(e => e.An03DataCreate)
                .HasColumnType("datetime")
                .HasColumnName("AN03_DATA_CREATE");
            entity.Property(e => e.An03DataUpdate)
                .HasColumnType("datetime")
                .HasColumnName("AN03_DATA_UPDATE");
            entity.Property(e => e.An03Deleted).HasColumnName("AN03_DELETED");
            entity.Property(e => e.An03Descrizione)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("AN03_DESCRIZIONE");
            entity.Property(e => e.An03DescrizioneEstesa)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("AN03_DESCRIZIONE_ESTESA");
            entity.Property(e => e.An03GiacenzaAttuale)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AN03_GIACENZA_ATTUALE");
            entity.Property(e => e.An03GiacenzaIniziale)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AN03_GIACENZA_INIZIALE");
            entity.Property(e => e.An03IvaGe03).HasColumnName("AN03_IVA_GE03");
            entity.Property(e => e.An03Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("AN03_NOTE");
            entity.Property(e => e.An03Prezzo)
                .HasColumnType("money")
                .HasColumnName("AN03_PREZZO");
            entity.Property(e => e.An03TipoPrezzo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AN03_TIPO_PREZZO");
            entity.Property(e => e.An03Um)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AN03_UM");
            entity.Property(e => e.An03UserCreateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN03_USER_CREATE_CF02");
            entity.Property(e => e.An03UserUpdateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AN03_USER_UPDATE_CF02");

            entity.HasOne(d => d.An03IvaGe03Navigation).WithMany(p => p.An03Articolos)
                .HasForeignKey(d => d.An03IvaGe03)
                .HasConstraintName("FK_AN03_IVA_GE03");

            entity.HasOne(d => d.An03TenantCf01Navigation).WithMany(p => p.An03Articolos)
                .HasForeignKey(d => d.An03TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AN03_CF01_TENANT");

            entity.HasOne(d => d.Cf06ClassArticolo).WithMany(p => p.An03Articolos)
                .HasForeignKey(d => new { d.An03TenantCf01, d.An03ClassificazioneCf06 })
                .HasConstraintName("FK_AN03_CLASSIFICAZIONE_CF06");

            entity.HasOne(d => d.Cf02Utente).WithMany(p => p.An03ArticoloCf02Utentes)
                .HasForeignKey(d => new { d.An03TenantCf01, d.An03UserCreateCf02 })
                .HasConstraintName("FK_AN03_USER_CREATE_CF02");

            entity.HasOne(d => d.Cf02UtenteNavigation).WithMany(p => p.An03ArticoloCf02UtenteNavigations)
                .HasForeignKey(d => new { d.An03TenantCf01, d.An03UserUpdateCf02 })
                .HasConstraintName("FK_AN03_USER_UPDATE_CF02");
        });

        modelBuilder.Entity<Cf01Tenant>(entity =>
        {
            entity.HasKey(e => e.Cf01Tenant1);

            entity.ToTable("CF01_TENANT");

            entity.Property(e => e.Cf01Tenant1)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CF01_TENANT");
            entity.Property(e => e.Cf01Datarinnovo)
                .HasColumnType("datetime")
                .HasColumnName("CF01_DATARINNOVO");
            entity.Property(e => e.Cf01Deleted).HasColumnName("CF01_DELETED");
            entity.Property(e => e.Cf01Nome)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CF01_NOME");
            entity.Property(e => e.Cf01TenantCf01).HasColumnName("CF01_TENANT_CF01");

            entity.HasOne(d => d.Cf01TenantCf01Navigation).WithMany(p => p.InverseCf01TenantCf01Navigation)
                .HasForeignKey(d => d.Cf01TenantCf01)
                .HasConstraintName("FK_CF01_TENANT_SELF");
        });

        modelBuilder.Entity<Cf02Utente>(entity =>
        {
            entity.HasKey(e => new { e.Cf02TenantCf01, e.Cf02Utente1 });

            entity.ToTable("CF02_UTENTE");

            entity.Property(e => e.Cf02TenantCf01).HasColumnName("CF02_TENANT_CF01");
            entity.Property(e => e.Cf02Utente1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CF02_UTENTE");
            entity.Property(e => e.Cf02Clienti).HasColumnName("CF02_CLIENTI");
            entity.Property(e => e.Cf02Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF02_EMAIL");
            entity.Property(e => e.Cf02Fornitori).HasColumnName("CF02_FORNITORI");
            entity.Property(e => e.Cf02Password)
                .IsUnicode(false)
                .HasColumnName("CF02_PASSWORD");
            entity.Property(e => e.Cf02Primanota).HasColumnName("CF02_PRIMANOTA");
            entity.Property(e => e.Cf02RuoloGe02).HasColumnName("CF02_RUOLO_GE02");
            entity.Property(e => e.Cf02Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CF02_TELEFONO");

            entity.HasOne(d => d.Cf02RuoloGe02Navigation).WithMany(p => p.Cf02Utentes)
                .HasForeignKey(d => d.Cf02RuoloGe02)
                .HasConstraintName("FK_CF02_UTENTE_GE02_RUOLO");

            entity.HasOne(d => d.Cf02TenantCf01Navigation).WithMany(p => p.Cf02Utentes)
                .HasForeignKey(d => d.Cf02TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF02_UTENTE_CF01_TENANT");
        });

        modelBuilder.Entity<Cf03ParametriConf>(entity =>
        {
            entity.HasKey(e => new { e.Cf03TenantCf01, e.Cf03Parametro });

            entity.ToTable("CF03_PARAMETRI_CONF");

            entity.Property(e => e.Cf03TenantCf01).HasColumnName("CF03_TENANT_CF01");
            entity.Property(e => e.Cf03Parametro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CF03_PARAMETRO");
            entity.Property(e => e.Cf03Raggruppamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CF03_RAGGRUPPAMENTO");
            entity.Property(e => e.Cf03ValoreBit).HasColumnName("CF03_VALORE_BIT");
            entity.Property(e => e.Cf03ValoreData)
                .HasColumnType("datetime")
                .HasColumnName("CF03_VALORE_DATA");
            entity.Property(e => e.Cf03ValoreDecimal)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("CF03_VALORE_DECIMAL");
            entity.Property(e => e.Cf03ValoreInt).HasColumnName("CF03_VALORE_INT");
            entity.Property(e => e.Cf03ValoreTesto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CF03_VALORE_TESTO");

            entity.HasOne(d => d.Cf03TenantCf01Navigation).WithMany(p => p.Cf03ParametriConfs)
                .HasForeignKey(d => d.Cf03TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF03_PARAMETRI_CONF_CF01_TENANT");
        });

        modelBuilder.Entity<Cf04Conto>(entity =>
        {
            entity.HasKey(e => new { e.Cf04TenantCf01, e.Cf04Conto1 });

            entity.ToTable("CF04_CONTO");

            entity.Property(e => e.Cf04TenantCf01).HasColumnName("CF04_TENANT_CF01");
            entity.Property(e => e.Cf04Conto1).HasColumnName("CF04_CONTO");
            entity.Property(e => e.Cf04CodiceSia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CF04_CODICE_SIA");
            entity.Property(e => e.Cf04Iban)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF04_IBAN");
            entity.Property(e => e.Cf04Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF04_NOME");
            entity.Property(e => e.Cf04Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CF04_TIPO");

            entity.HasOne(d => d.Cf04TenantCf01Navigation).WithMany(p => p.Cf04Contos)
                .HasForeignKey(d => d.Cf04TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF04_CONTO_CF01_TENANT");
        });

        modelBuilder.Entity<Cf05Pagamento>(entity =>
        {
            entity.HasKey(e => new { e.Cf05Tenant, e.Cf05Pagamento1 });

            entity.ToTable("CF05_PAGAMENTO");

            entity.Property(e => e.Cf05Tenant).HasColumnName("CF05_TENANT");
            entity.Property(e => e.Cf05Pagamento1).HasColumnName("CF05_PAGAMENTO");
            entity.Property(e => e.Cf05ContoCf04).HasColumnName("CF05_CONTO_CF04");
            entity.Property(e => e.Cf05Descrizione1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_DESCRIZIONE1");
            entity.Property(e => e.Cf05Descrizione2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_DESCRIZIONE2");
            entity.Property(e => e.Cf05Descrizione3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_DESCRIZIONE3");
            entity.Property(e => e.Cf05Descrizione4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_DESCRIZIONE4");
            entity.Property(e => e.Cf05Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_NOME");
            entity.Property(e => e.Cf05Predefinito)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CF05_PREDEFINITO");
            entity.Property(e => e.Cf05Tipologia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CF05_TIPOLOGIA");
            entity.Property(e => e.Cf05Valore1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_VALORE1");
            entity.Property(e => e.Cf05Valore2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_VALORE2");
            entity.Property(e => e.Cf05Valore3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_VALORE3");
            entity.Property(e => e.Cf05Valore4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF05_VALORE4");

            entity.HasOne(d => d.Cf05TenantNavigation).WithMany(p => p.Cf05Pagamentos)
                .HasForeignKey(d => d.Cf05Tenant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF05_PAGAMENTO_CF01_TENANT");
        });

        modelBuilder.Entity<Cf06ClassArticolo>(entity =>
        {
            entity.HasKey(e => new { e.Cf06TenantCf01, e.Cf06Classificazione });

            entity.ToTable("CF06_CLASS_ARTICOLO");

            entity.Property(e => e.Cf06TenantCf01).HasColumnName("CF06_TENANT_CF01");
            entity.Property(e => e.Cf06Classificazione).HasColumnName("CF06_CLASSIFICAZIONE");
            entity.Property(e => e.Cf06Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF06_NOME");

            entity.HasOne(d => d.Cf06TenantCf01Navigation).WithMany(p => p.Cf06ClassArticolos)
                .HasForeignKey(d => d.Cf06TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF06_CLASS_ARTICOLO_CF01_TENANT");
        });

        modelBuilder.Entity<Cf07Numerazione>(entity =>
        {
            entity.HasKey(e => new { e.Cf07TenantCf01, e.Cg07Anno, e.Cg07CausaleGe10, e.Cf07Serie });

            entity.ToTable("CF07_NUMERAZIONE");

            entity.Property(e => e.Cf07TenantCf01).HasColumnName("CF07_TENANT_CF01");
            entity.Property(e => e.Cg07Anno).HasColumnName("CG07_ANNO");
            entity.Property(e => e.Cg07CausaleGe10).HasColumnName("CG07_CAUSALE_GE10");
            entity.Property(e => e.Cf07Serie)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CF07_SERIE");
            entity.Property(e => e.Cf07Numero).HasColumnName("CF07_NUMERO");

            entity.HasOne(d => d.Cf07TenantCf01Navigation).WithMany(p => p.Cf07Numeraziones)
                .HasForeignKey(d => d.Cf07TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF07_CF01_TENANT");

            entity.HasOne(d => d.Cg07CausaleGe10Navigation).WithMany(p => p.Cf07Numeraziones)
                .HasForeignKey(d => d.Cg07CausaleGe10)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF07_NUMERAZIONE_GE10_CAU_DOCUMENTO");
        });

        modelBuilder.Entity<Cf08Smtp>(entity =>
        {
            entity.HasKey(e => e.Cf08TenantCf01);

            entity.ToTable("CF08_SMTP");

            entity.Property(e => e.Cf08TenantCf01)
                .ValueGeneratedNever()
                .HasColumnName("CF08_TENANT_CF01");
            entity.Property(e => e.Cf08Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF08_EMAIL");
            entity.Property(e => e.Cf08Mittente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF08_MITTENTE");
            entity.Property(e => e.Cf08Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF08_PASSWORD");
            entity.Property(e => e.Cf08Porta).HasColumnName("CF08_PORTA");
            entity.Property(e => e.Cf08ServerSmtp)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CF08_SERVER_SMTP");
            entity.Property(e => e.Cf08Sicurezza)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CF08_SICUREZZA");
            entity.Property(e => e.Cf08Utente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CF08_UTENTE");

            entity.HasOne(d => d.Cf08TenantCf01Navigation).WithOne(p => p.Cf08Smtp)
                .HasForeignKey<Cf08Smtp>(d => d.Cf08TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF08_SMTP_CF01_TENANT");
        });

        modelBuilder.Entity<Cf08Sollecito>(entity =>
        {
            entity.HasKey(e => new { e.Cf08TenantCf01, e.Cf08Sollecito1 });

            entity.ToTable("CF08_SOLLECITO");

            entity.Property(e => e.Cf08TenantCf01).HasColumnName("CF08_TENANT_CF01");
            entity.Property(e => e.Cf08Sollecito1).HasColumnName("CF08_SOLLECITO");
            entity.Property(e => e.Cf08FlgFatture).HasColumnName("CF08_FLG_FATTURE");
            entity.Property(e => e.Cf08FlgProforma).HasColumnName("CF08_FLG_PROFORMA");
            entity.Property(e => e.Cf08FlgRicevute).HasColumnName("CF08_FLG_RICEVUTE");
            entity.Property(e => e.Cf08Giorni).HasColumnName("CF08_GIORNI");
            entity.Property(e => e.Cf08Importida)
                .HasColumnType("money")
                .HasColumnName("CF08_IMPORTIDA");
            entity.Property(e => e.Cf08Inviail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CF08_INVIAIL");
            entity.Property(e => e.Cf08Messaggio)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("CF08_MESSAGGIO");
            entity.Property(e => e.Cf08Oggetto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CF08_OGGETTO");

            entity.HasOne(d => d.Cf08TenantCf01Navigation).WithMany(p => p.Cf08Sollecitos)
                .HasForeignKey(d => d.Cf08TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CF08_SOLLECITO_CF01_TENANT");
        });

        modelBuilder.Entity<Cg01PrimaNotum>(entity =>
        {
            entity.HasKey(e => new { e.Cg01TenantCf01, e.Cg01Keypn });

            entity.ToTable("CG01_PRIMA_NOTA");

            entity.Property(e => e.Cg01TenantCf01).HasColumnName("CG01_TENANT_CF01");
            entity.Property(e => e.Cg01Keypn).HasColumnName("CG01_KEYPN");
            entity.Property(e => e.Cg01AnagraficaAn02).HasColumnName("CG01_ANAGRAFICA_AN02");
            entity.Property(e => e.Cg01CliforAn02)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CG01_CLIFOR_AN02");
            entity.Property(e => e.Cg01ContoEntrataCf04).HasColumnName("CG01_CONTO_ENTRATA_CF04");
            entity.Property(e => e.Cg01ContoUscitaCf04).HasColumnName("CG01_CONTO_USCITA_CF04");
            entity.Property(e => e.Cg01Data)
                .HasColumnType("datetime")
                .HasColumnName("CG01_DATA");
            entity.Property(e => e.Cg01Deleted).HasColumnName("CG01_DELETED");
            entity.Property(e => e.Cg01Entrate)
                .HasColumnType("money")
                .HasColumnName("CG01_ENTRATE");
            entity.Property(e => e.Cg01Note)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CG01_NOTE");
            entity.Property(e => e.Cg01Uscite)
                .HasColumnType("money")
                .HasColumnName("CG01_USCITE");

            entity.HasOne(d => d.Cg01TenantCf01Navigation).WithMany(p => p.Cg01PrimaNota)
                .HasForeignKey(d => d.Cg01TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CG01_CF01_TENANT");

            entity.HasOne(d => d.Cf04Conto).WithMany(p => p.Cg01PrimaNotumCf04Contos)
                .HasForeignKey(d => new { d.Cg01TenantCf01, d.Cg01ContoEntrataCf04 })
                .HasConstraintName("FK_CG01_CONTO_ENTRATA_CF04");

            entity.HasOne(d => d.Cf04ContoNavigation).WithMany(p => p.Cg01PrimaNotumCf04ContoNavigations)
                .HasForeignKey(d => new { d.Cg01TenantCf01, d.Cg01ContoUscitaCf04 })
                .HasConstraintName("FK_CG01_CONTO_USCITA_CF04");

            entity.HasOne(d => d.An02Anagrafica).WithMany(p => p.Cg01PrimaNota)
                .HasForeignKey(d => new { d.Cg01TenantCf01, d.Cg01CliforAn02, d.Cg01AnagraficaAn02 })
                .HasConstraintName("FK_CG01_ANAGRAFICA_AN02");
        });

        modelBuilder.Entity<Cg02F24>(entity =>
        {
            entity.HasKey(e => new { e.Cg02TenantCf01, e.Cg02Keyf24 });

            entity.ToTable("CG02_F24");

            entity.Property(e => e.Cg02TenantCf01).HasColumnName("CG02_TENANT_CF01");
            entity.Property(e => e.Cg02Keyf24).HasColumnName("CG02_KEYF24");
            entity.Property(e => e.Cg02ContoCf04).HasColumnName("CG02_CONTO_CF04");
            entity.Property(e => e.Cg02Data)
                .HasColumnType("datetime")
                .HasColumnName("CG02_DATA");
            entity.Property(e => e.Cg02Deleted).HasColumnName("CG02_DELETED");
            entity.Property(e => e.Cg02Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CG02_DESCRIZIONE");
            entity.Property(e => e.Cg02Stato)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CG02_STATO");
            entity.Property(e => e.Cg02Uscite)
                .HasColumnType("money")
                .HasColumnName("CG02_USCITE");

            entity.HasOne(d => d.Cg02TenantCf01Navigation).WithMany(p => p.Cg02F24s)
                .HasForeignKey(d => d.Cg02TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CG02_CF01");

            entity.HasOne(d => d.Cf04Conto).WithMany(p => p.Cg02F24s)
                .HasForeignKey(d => new { d.Cg02TenantCf01, d.Cg02ContoCf04 })
                .HasConstraintName("FK_CG02_CONTO_CF04");
        });

        modelBuilder.Entity<Do01TestataDocumento>(entity =>
        {
            entity.HasKey(e => new { e.Do01TenantCf01, e.Do01Keydoc });

            entity.ToTable("DO01_TESTATA_DOCUMENTO");

            entity.Property(e => e.Do01TenantCf01).HasColumnName("DO01_TENANT_CF01");
            entity.Property(e => e.Do01Keydoc).HasColumnName("DO01_KEYDOC");
            entity.Property(e => e.Do01AnagraficaAn02).HasColumnName("DO01_ANAGRAFICA_AN02");
            entity.Property(e => e.Do01AnnoCg07).HasColumnName("DO01_ANNO_CG07");
            entity.Property(e => e.Do01CausaleCg07).HasColumnName("DO01_CAUSALE_CG07");
            entity.Property(e => e.Do01CentroCosto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DO01_CENTRO_COSTO");
            entity.Property(e => e.Do01CliforAn02)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO01_CLIFOR_AN02");
            entity.Property(e => e.Do01CondpagGe17)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO01_CONDPAG_GE17");
            entity.Property(e => e.Do01Data)
                .HasColumnType("datetime")
                .HasColumnName("DO01_DATA");
            entity.Property(e => e.Do01DataCreate)
                .HasColumnType("datetime")
                .HasColumnName("DO01_DATA_CREATE");
            entity.Property(e => e.Do01DataUpdate)
                .HasColumnType("datetime")
                .HasColumnName("DO01_DATA_UPDATE");
            entity.Property(e => e.Do01Deleted).HasColumnName("DO01_DELETED");
            entity.Property(e => e.Do01FeCodicedestinatario)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("DO01_FE_CODICEDESTINATARIO");
            entity.Property(e => e.Do01FePecdestinatario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DO01_FE_PECDESTINATARIO");
            entity.Property(e => e.Do01Imponibile)
                .HasColumnType("money")
                .HasColumnName("DO01_IMPONIBILE");
            entity.Property(e => e.Do01Imposta)
                .HasColumnType("money")
                .HasColumnName("DO01_IMPOSTA");
            entity.Property(e => e.Do01LinguaGe12)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DO01_LINGUA_GE12");
            entity.Property(e => e.Do01MargineOrz).HasColumnName("DO01_MARGINE_ORZ");
            entity.Property(e => e.Do01MargineVer).HasColumnName("DO01_MARGINE_VER");
            entity.Property(e => e.Do01ModelloGe13)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DO01_MODELLO_GE13");
            entity.Property(e => e.Do01Mostratot).HasColumnName("DO01_MOSTRATOT");
            entity.Property(e => e.Do01Notedoc)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DO01_NOTEDOC");
            entity.Property(e => e.Do01Numero).HasColumnName("DO01_NUMERO");
            entity.Property(e => e.Do01OggettoNas)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DO01_OGGETTO_NAS");
            entity.Property(e => e.Do01OggettoVis)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DO01_OGGETTO_VIS");
            entity.Property(e => e.Do01Pa).HasColumnName("DO01_PA");
            entity.Property(e => e.Do01PercRivalsa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PERC_RIVALSA");
            entity.Property(e => e.Do01PercimpPrimacassa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PERCIMP_PRIMACASSA");
            entity.Property(e => e.Do01PercimpPrimaritenuta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PERCIMP_PRIMARITENUTA");
            entity.Property(e => e.Do01PercimpSecondacassa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PERCIMP_SECONDACASSA");
            entity.Property(e => e.Do01PercimpSecondaritenuta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PERCIMP_SECONDARITENUTA");
            entity.Property(e => e.Do01Primacassa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PRIMACASSA");
            entity.Property(e => e.Do01Primaritenuta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_PRIMARITENUTA");
            entity.Property(e => e.Do01RivalsaIva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_RIVALSA_IVA");
            entity.Property(e => e.Do01Secondacassa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_SECONDACASSA");
            entity.Property(e => e.Do01Secondaritenuta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO01_SECONDARITENUTA");
            entity.Property(e => e.Do01SerieCg07)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("DO01_SERIE_CG07");
            entity.Property(e => e.Do01SoggettoEmittente)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO01_SOGGETTO_EMITTENTE");
            entity.Property(e => e.Do01Stato)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO01_STATO");
            entity.Property(e => e.Do01Targa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DO01_TARGA");
            entity.Property(e => e.Do01TassoCambio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DO01_TASSO_CAMBIO");
            entity.Property(e => e.Do01TipodocFepaGe18)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO01_TIPODOC_FEPA_GE18");
            entity.Property(e => e.Do01Totale)
                .HasColumnType("money")
                .HasColumnName("DO01_TOTALE");
            entity.Property(e => e.Do01UserCreateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO01_USER_CREATE_CF02");
            entity.Property(e => e.Do01UserUpdateCf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO01_USER_UPDATE_CF02");
            entity.Property(e => e.Do01ValutaGe11)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DO01_VALUTA_GE11");
            entity.Property(e => e.Do11PagamentoCf05).HasColumnName("DO11_PAGAMENTO_CF05");

            entity.HasOne(d => d.Do01CausaleCg07Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01CausaleCg07)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO01_CAUSALE_CG10");

            entity.HasOne(d => d.Do01CondpagGe17Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01CondpagGe17)
                .HasConstraintName("FK_DO01_CONDPAG_GE17");

            entity.HasOne(d => d.Do01LinguaGe12Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01LinguaGe12)
                .HasConstraintName("FK_DO01_LINGUA_GE12");

            entity.HasOne(d => d.Do01ModelloGe13Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01ModelloGe13)
                .HasConstraintName("FK_DO01_MODELLO_GE13");

            entity.HasOne(d => d.Do01TenantCf01Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01TenantCf01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO01_CF01_TENANT");

            entity.HasOne(d => d.Do01TipodocFepaGe18Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01TipodocFepaGe18)
                .HasConstraintName("FK_DO01_CONDPAG_GE18");

            entity.HasOne(d => d.Do01ValutaGe11Navigation).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => d.Do01ValutaGe11)
                .HasConstraintName("FK_DO01_VALUTA_GE11");

            entity.HasOne(d => d.Cf02Utente).WithMany(p => p.Do01TestataDocumentoCf02Utentes)
                .HasForeignKey(d => new { d.Do01TenantCf01, d.Do01UserCreateCf02 })
                .HasConstraintName("FK_DO01_USER_CREATE_CF02");

            entity.HasOne(d => d.Cf02UtenteNavigation).WithMany(p => p.Do01TestataDocumentoCf02UtenteNavigations)
                .HasForeignKey(d => new { d.Do01TenantCf01, d.Do01UserUpdateCf02 })
                .HasConstraintName("FK_DO01_USER_UPDATE_CF02");

            entity.HasOne(d => d.Cf05Pagamento).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => new { d.Do01TenantCf01, d.Do11PagamentoCf05 })
                .HasConstraintName("FK_DO11_PAGAMENTO_CF05");

            entity.HasOne(d => d.Cf07Numerazione).WithMany(p => p.Do01TestataDocumentos)
                .HasForeignKey(d => new { d.Do01TenantCf01, d.Do01CausaleCg07, d.Do01AnnoCg07, d.Do01SerieCg07 })
                .HasConstraintName("FK_DO01_CAUSALE_CG07");
        });

        modelBuilder.Entity<Do02Scadenze>(entity =>
        {
            entity.HasKey(e => new { e.Do02TenantCf01, e.Do02Keydoc, e.Do02Keyscad });

            entity.ToTable("DO02_SCADENZE");

            entity.Property(e => e.Do02TenantCf01).HasColumnName("DO02_TENANT_CF01");
            entity.Property(e => e.Do02Keydoc).HasColumnName("DO02_KEYDOC");
            entity.Property(e => e.Do02Keyscad).HasColumnName("DO02_KEYSCAD");
            entity.Property(e => e.Do02Datascadenza)
                .HasColumnType("datetime")
                .HasColumnName("DO02_DATASCADENZA");
            entity.Property(e => e.Do02Deleted).HasColumnName("DO02_DELETED");
            entity.Property(e => e.Do02Giorniscadenza).HasColumnName("DO02_GIORNISCADENZA");
            entity.Property(e => e.Do02Importo)
                .HasColumnType("money")
                .HasColumnName("DO02_IMPORTO");
            entity.Property(e => e.Do02Stato).HasColumnName("DO02_STATO");
            entity.Property(e => e.Do02Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO02_TIPO");

            entity.HasOne(d => d.Do01TestataDocumento).WithMany(p => p.Do02Scadenzes)
                .HasForeignKey(d => new { d.Do02TenantCf01, d.Do02Keydoc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO02_DO01_TESTATA");
        });

        modelBuilder.Entity<Do03DocorigineFepa>(entity =>
        {
            entity.HasKey(e => new { e.Do03TenantCf01, e.Do03Keydoc, e.Do03Tipo, e.Do03Rigaid });

            entity.ToTable("DO03_DOCORIGINE_FEPA");

            entity.Property(e => e.Do03TenantCf01).HasColumnName("DO03_TENANT_CF01");
            entity.Property(e => e.Do03Keydoc).HasColumnName("DO03_KEYDOC");
            entity.Property(e => e.Do03Tipo).HasColumnName("DO03_TIPO");
            entity.Property(e => e.Do03Rigaid).HasColumnName("DO03_RIGAID");
            entity.Property(e => e.Do03Cig)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DO03_CIG");
            entity.Property(e => e.Do03Commessa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DO03_COMMESSA");
            entity.Property(e => e.Do03Cup)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DO03_CUP");
            entity.Property(e => e.Do03Data).HasColumnName("DO03_DATA");
            entity.Property(e => e.Do03Iddocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DO03_IDDOCUMENTO");
            entity.Property(e => e.Do03Numitem)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DO03_NUMITEM");

            entity.HasOne(d => d.Do01TestataDocumento).WithMany(p => p.Do03DocorigineFepas)
                .HasForeignKey(d => new { d.Do03TenantCf01, d.Do03Keydoc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO03_DO01_TESTATA");
        });

        modelBuilder.Entity<Do04PagamentoFepa>(entity =>
        {
            entity.HasKey(e => new { e.Do04TenantCf01, e.Do04Keydoc, e.Do04Rigaid });

            entity.ToTable("DO04_PAGAMENTO_FEPA");

            entity.Property(e => e.Do04TenantCf01).HasColumnName("DO04_TENANT_CF01");
            entity.Property(e => e.Do04Keydoc).HasColumnName("DO04_KEYDOC");
            entity.Property(e => e.Do04Rigaid).HasColumnName("DO04_RIGAID");
            entity.Property(e => e.Do04Abi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("DO04_ABI");
            entity.Property(e => e.Do04Banca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DO04_BANCA");
            entity.Property(e => e.Do04Cab)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("DO04_CAB");
            entity.Property(e => e.Do04Datarifpag).HasColumnName("DO04_DATARIFPAG");
            entity.Property(e => e.Do04Datascadenza).HasColumnName("DO04_DATASCADENZA");
            entity.Property(e => e.Do04Iban)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO04_IBAN");
            entity.Property(e => e.Do04Importo)
                .HasColumnType("money")
                .HasColumnName("DO04_IMPORTO");
            entity.Property(e => e.Do04PagFepaGe15)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DO04_PAG_FEPA_GE15");

            entity.HasOne(d => d.Do04PagFepaGe15Navigation).WithMany(p => p.Do04PagamentoFepas)
                .HasForeignKey(d => d.Do04PagFepaGe15)
                .HasConstraintName("FK_DO04_PAG_FEPA_GE15");

            entity.HasOne(d => d.Do01TestataDocumento).WithMany(p => p.Do04PagamentoFepas)
                .HasForeignKey(d => new { d.Do04TenantCf01, d.Do04Keydoc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO04_DO01_TESTATA");
        });

        modelBuilder.Entity<Do05AltridatiFepa>(entity =>
        {
            entity.HasKey(e => new { e.Do05TenantCf01, e.Do05KeydocDo01, e.Do05KeyaltridatiGe16, e.Do05Numitem, e.Do05Numrigadoc });

            entity.ToTable("DO05_ALTRIDATI_FEPA");

            entity.Property(e => e.Do05TenantCf01)
                .HasComment("ZERO SE LEGATA ALLA TESTATA N RIGA SE LEGATO ALLA TABELLA RIGA")
                .HasColumnName("DO05_TENANT_CF01");
            entity.Property(e => e.Do05KeydocDo01).HasColumnName("DO05_KEYDOC_DO01");
            entity.Property(e => e.Do05KeyaltridatiGe16).HasColumnName("DO05_KEYALTRIDATI_GE16");
            entity.Property(e => e.Do05Numitem).HasColumnName("DO05_NUMITEM");
            entity.Property(e => e.Do05Numrigadoc).HasColumnName("DO05_NUMRIGADOC");
            entity.Property(e => e.Do05Valore)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DO05_VALORE");

            entity.HasOne(d => d.Do01TestataDocumento).WithMany(p => p.Do05AltridatiFepas)
                .HasForeignKey(d => new { d.Do05TenantCf01, d.Do05KeydocDo01 })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO05_DO01_TESTATA");
        });

        modelBuilder.Entity<Do10CorpoDocumento>(entity =>
        {
            entity.HasKey(e => new { e.Do10TenantCf01, e.Do10Keydoc, e.Do10Numriga });

            entity.ToTable("DO10_CORPO_DOCUMENTO");

            entity.Property(e => e.Do10TenantCf01).HasColumnName("DO10_TENANT_CF01");
            entity.Property(e => e.Do10Keydoc).HasColumnName("DO10_KEYDOC");
            entity.Property(e => e.Do10Numriga).HasColumnName("DO10_NUMRIGA");
            entity.Property(e => e.Do01TipocessioneFepa)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO01_TIPOCESSIONE_FEPA");
            entity.Property(e => e.Do10ArticoloAn03).HasColumnName("DO10_ARTICOLO_AN03");
            entity.Property(e => e.Do10CatCostoRicavo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO10_CAT_COSTO_RICAVO");
            entity.Property(e => e.Do10CodiceArticolo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DO10_CODICE_ARTICOLO");
            entity.Property(e => e.Do10CodiceivaGe03).HasColumnName("DO10_CODICEIVA_GE03");
            entity.Property(e => e.Do10Deleted).HasColumnName("DO10_DELETED");
            entity.Property(e => e.Do10Descrizione)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DO10_DESCRIZIONE");
            entity.Property(e => e.Do10FlgNonimponibile).HasColumnName("DO10_FLG_NONIMPONIBILE");
            entity.Property(e => e.Do10FlgRitenuteCassa).HasColumnName("DO10_FLG_RITENUTE_CASSA");
            entity.Property(e => e.Do10Importo)
                .HasColumnType("money")
                .HasColumnName("DO10_IMPORTO");
            entity.Property(e => e.Do10KeydocoriginDo10).HasColumnName("DO10_KEYDOCORIGIN_DO10");
            entity.Property(e => e.Do10NumrigaoriginDo10).HasColumnName("DO10_NUMRIGAORIGIN_DO10");
            entity.Property(e => e.Do10Perciva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO10_PERCIVA");
            entity.Property(e => e.Do10Perdetr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO10_PERDETR");
            entity.Property(e => e.Do10Przlordo)
                .HasColumnType("money")
                .HasColumnName("DO10_PRZLORDO");
            entity.Property(e => e.Do10Prznetto)
                .HasColumnType("money")
                .HasColumnName("DO10_PRZNETTO");
            entity.Property(e => e.Do10Sc1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO10_SC1");
            entity.Property(e => e.Do10Um)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DO10_UM");

            entity.HasOne(d => d.Do10CodiceivaGe03Navigation).WithMany(p => p.Do10CorpoDocumentos)
                .HasForeignKey(d => d.Do10CodiceivaGe03)
                .HasConstraintName("FK_DO10_CODICEIVA_GE03");

            entity.HasOne(d => d.An03Articolo).WithMany(p => p.Do10CorpoDocumentos)
                .HasForeignKey(d => new { d.Do10TenantCf01, d.Do10ArticoloAn03 })
                .HasConstraintName("FK_DO10_ARTICOLO_AN03");

            entity.HasOne(d => d.Do01TestataDocumento).WithMany(p => p.Do10CorpoDocumentos)
                .HasForeignKey(d => new { d.Do10TenantCf01, d.Do10Keydoc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO10_DO01_TESTATA");

            entity.HasOne(d => d.Do10CorpoDocumentoNavigation).WithMany(p => p.InverseDo10CorpoDocumentoNavigation)
                .HasForeignKey(d => new { d.Do10TenantCf01, d.Do10KeydocoriginDo10, d.Do10NumrigaoriginDo10 })
                .HasConstraintName("FK_DO10_DOCORIGIN_DO10");
        });

        modelBuilder.Entity<Do20Castellettoiva>(entity =>
        {
            entity.HasKey(e => new { e.Do20TenantCf01, e.Do20Keydoc, e.Do20CodiceivaGe03 });

            entity.ToTable("DO20_CASTELLETTOIVA");

            entity.Property(e => e.Do20TenantCf01).HasColumnName("DO20_TENANT_CF01");
            entity.Property(e => e.Do20Keydoc).HasColumnName("DO20_KEYDOC");
            entity.Property(e => e.Do20CodiceivaGe03).HasColumnName("DO20_CODICEIVA_GE03");
            entity.Property(e => e.Do20Esigibilita)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DO20_ESIGIBILITA");
            entity.Property(e => e.Do20Imponibile)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO20_IMPONIBILE");
            entity.Property(e => e.Do20Imposta)
                .HasColumnType("money")
                .HasColumnName("DO20_IMPOSTA");
            entity.Property(e => e.Do20Perciva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DO20_PERCIVA");
            entity.Property(e => e.Do20RiferimentoNormativo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DO20_RIFERIMENTO_NORMATIVO");

            entity.HasOne(d => d.Do20CodiceivaGe03Navigation).WithMany(p => p.Do20Castellettoivas)
                .HasForeignKey(d => d.Do20CodiceivaGe03)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO20_CODICEIVA_GE03");

            entity.HasOne(d => d.Do01TestataDocumento).WithMany(p => p.Do20Castellettoivas)
                .HasForeignKey(d => new { d.Do20TenantCf01, d.Do20Keydoc })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DO20_DO01_TESTATA");
        });

        modelBuilder.Entity<Ge01Comuni>(entity =>
        {
            entity.HasKey(e => e.Ge01Comune);

            entity.ToTable("GE01_COMUNI");

            entity.Property(e => e.Ge01Comune)
                .ValueGeneratedNever()
                .HasColumnName("GE01_COMUNE");
            entity.Property(e => e.Ge01Cap)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE01_CAP");
            entity.Property(e => e.Ge01Codiceistat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE01_CODICEISTAT");
            entity.Property(e => e.Ge01Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE01_NOME");
            entity.Property(e => e.Ge01Provincia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GE01_PROVINCIA");
            entity.Property(e => e.Ge01Regione)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GE01_REGIONE");
            entity.Property(e => e.Ge01Stato)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE01_STATO");
            entity.Property(e => e.Ge02CodiceStato)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE02_CODICE_STATO");
        });

        modelBuilder.Entity<Ge02Ruoli>(entity =>
        {
            entity.HasKey(e => e.Ge02Ruolo);

            entity.ToTable("GE02_RUOLI");

            entity.Property(e => e.Ge02Ruolo)
                .ValueGeneratedNever()
                .HasColumnName("GE02_RUOLO");
            entity.Property(e => e.Ge02Descrizione)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GE02_DESCRIZIONE");
            entity.Property(e => e.Ge02Gerarchia).HasColumnName("GE02_GERARCHIA");
            entity.Property(e => e.Ge02Note)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("GE02_NOTE");
        });

        modelBuilder.Entity<Ge03Iva>(entity =>
        {
            entity.HasKey(e => e.Ge03CodiceIva);

            entity.ToTable("GE03_IVA");

            entity.Property(e => e.Ge03CodiceIva)
                .ValueGeneratedNever()
                .HasColumnName("GE03_CODICE_IVA");
            entity.Property(e => e.Ge03CodiceFatturapa)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("GE03_CODICE_FATTURAPA");
            entity.Property(e => e.Ge03Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GE03_DESCRIZIONE");
            entity.Property(e => e.Ge03Iva1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("GE03_IVA");
            entity.Property(e => e.Ge03PercIndetraibilita)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("GE03_PERC_INDETRAIBILITA");
        });

        modelBuilder.Entity<Ge04RegimeFiscale>(entity =>
        {
            entity.HasKey(e => e.Ge04RegimeFiscale1);

            entity.ToTable("GE04_REGIME_FISCALE");

            entity.Property(e => e.Ge04RegimeFiscale1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE04_REGIME_FISCALE");
            entity.Property(e => e.Ge04Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GE04_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge05CassaProf>(entity =>
        {
            entity.HasKey(e => e.Ge05Cassa);

            entity.ToTable("GE05_CASSA_PROF");

            entity.Property(e => e.Ge05Cassa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE05_CASSA");
            entity.Property(e => e.Ge05Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GE05_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge06TipoRitenutum>(entity =>
        {
            entity.HasKey(e => e.Ge06TipoRitenuta);

            entity.ToTable("GE06_TIPO_RITENUTA");

            entity.Property(e => e.Ge06TipoRitenuta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE06_TIPO_RITENUTA");
            entity.Property(e => e.Ge06Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE06_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge07CausPagRitenutum>(entity =>
        {
            entity.HasKey(e => e.Ge07CauPagRit);

            entity.ToTable("GE07_CAUS_PAG_RITENUTA");

            entity.Property(e => e.Ge07CauPagRit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE07_CAU_PAG_RIT");
            entity.Property(e => e.Ge07Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE07_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge08Provincium>(entity =>
        {
            entity.HasKey(e => e.Ge08Provincia);

            entity.ToTable("GE08_PROVINCIA");

            entity.Property(e => e.Ge08Provincia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE08_PROVINCIA");
            entity.Property(e => e.Ge08Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE08_NOME");
        });

        modelBuilder.Entity<Ge09Stato>(entity =>
        {
            entity.HasKey(e => e.Ge09Stato1);

            entity.ToTable("GE09_STATO");

            entity.Property(e => e.Ge09Stato1)
                .ValueGeneratedNever()
                .HasColumnName("GE09_STATO");
            entity.Property(e => e.Ge09Codice)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GE09_CODICE");
            entity.Property(e => e.Ge09Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE09_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge10CauDocumento>(entity =>
        {
            entity.HasKey(e => e.Ge10Causale);

            entity.ToTable("GE10_CAU_DOCUMENTO");

            entity.Property(e => e.Ge10Causale)
                .ValueGeneratedNever()
                .HasColumnName("GE10_CAUSALE");
            entity.Property(e => e.Ge10Documento).HasColumnName("GE10_DOCUMENTO");
            entity.Property(e => e.Ge10FepaTipodocumento)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE10_FEPA_TIPODOCUMENTO");
            entity.Property(e => e.Ge10Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE10_NOME");
            entity.Property(e => e.Ge10TipoClifor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE10_TIPO_CLIFOR");
        });

        modelBuilder.Entity<Ge11Valutum>(entity =>
        {
            entity.HasKey(e => e.Ge11Valuta);

            entity.ToTable("GE11_VALUTA");

            entity.Property(e => e.Ge11Valuta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE11_VALUTA");
            entity.Property(e => e.Ge11DataUltimoAggiornamento)
                .HasColumnType("datetime")
                .HasColumnName("GE11_DATA_ULTIMO_AGGIORNAMENTO");
            entity.Property(e => e.Ge11TassoCambio)
                .HasColumnType("money")
                .HasColumnName("GE11_TASSO_CAMBIO");
        });

        modelBuilder.Entity<Ge12Lingua>(entity =>
        {
            entity.HasKey(e => e.Ge12Lingua1);

            entity.ToTable("GE12_LINGUA");

            entity.Property(e => e.Ge12Lingua1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE12_LINGUA");
            entity.Property(e => e.Ge12Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE12_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge13ModelloStampa>(entity =>
        {
            entity.HasKey(e => e.Ge13Modello);

            entity.ToTable("GE13_MODELLO_STAMPA");

            entity.Property(e => e.Ge13Modello)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GE13_MODELLO");
            entity.Property(e => e.Ge13Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE13_DESCRIZIONE");
            entity.Property(e => e.Ge13MargOrizMm).HasColumnName("GE13_MARG_ORIZ_MM");
            entity.Property(e => e.Ge13MargVertMm).HasColumnName("GE13_MARG_VERT_MM");
        });

        modelBuilder.Entity<Ge14Um>(entity =>
        {
            entity.HasKey(e => e.Ge14Um1);

            entity.ToTable("GE14_UM");

            entity.Property(e => e.Ge14Um1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GE14_UM");
        });

        modelBuilder.Entity<Ge15ModalitaPagFepa>(entity =>
        {
            entity.HasKey(e => e.Ge15Codice).HasName("PK_GE15_PAG_FEPA");

            entity.ToTable("GE15_MODALITA_PAG_FEPA");

            entity.Property(e => e.Ge15Codice)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GE15_CODICE");
            entity.Property(e => e.Ge15Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE15_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge16AltriDatiFepa>(entity =>
        {
            entity.HasKey(e => e.Ge16Key);

            entity.ToTable("GE16_ALTRI_DATI_FEPA");

            entity.Property(e => e.Ge16Key)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GE16_KEY");
            entity.Property(e => e.Ge16CodiceRif)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_CODICE_RIF");
            entity.Property(e => e.Ge16Datatype).HasColumnName("GE16_DATATYPE");
            entity.Property(e => e.Ge16Default)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GE16_DEFAULT");
            entity.Property(e => e.Ge16DescrizioneRif)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_DESCRIZIONE_RIF");
            entity.Property(e => e.Ge16Liv1Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_LIV1_DESCRIZIONE");
            entity.Property(e => e.Ge16Liv2Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_LIV2_DESCRIZIONE");
            entity.Property(e => e.Ge16Liv3Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_LIV3_DESCRIZIONE");
            entity.Property(e => e.Ge16Liv3Multiriga).HasColumnName("GE16_LIV3_MULTIRIGA");
            entity.Property(e => e.Ge16Liv4Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_LIV4_DESCRIZIONE");
            entity.Property(e => e.Ge16Liv4Multiriga).HasColumnName("GE16_LIV4_MULTIRIGA");
            entity.Property(e => e.Ge16Liv5Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_LIV5_DESCRIZIONE");
            entity.Property(e => e.Ge16Liv6Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_LIV6_DESCRIZIONE");
            entity.Property(e => e.Ge16TabellaRif)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE16_TABELLA_RIF");
            entity.Property(e => e.Ge16TestataRiga)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE16_TESTATA_RIGA");
        });

        modelBuilder.Entity<Ge17CondPagFepa>(entity =>
        {
            entity.HasKey(e => e.Ge17Codice);

            entity.ToTable("GE17_COND_PAG_FEPA");

            entity.Property(e => e.Ge17Codice)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE17_CODICE");
            entity.Property(e => e.Ge17Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE17_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge18TipoDocFepa>(entity =>
        {
            entity.HasKey(e => e.Ge18Codice);

            entity.ToTable("GE18_TIPO_DOC_FEPA");

            entity.Property(e => e.Ge18Codice)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GE18_CODICE");
            entity.Property(e => e.Ge18Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GE18_DESCRIZIONE");
        });

        modelBuilder.Entity<Ge19TipocessionePrestazione>(entity =>
        {
            entity.HasKey(e => e.Ge19Codice).HasName("PK_GE19_TIPOCESSIONEPRESTAZIONE");

            entity.ToTable("GE19_TIPOCESSIONE_PRESTAZIONE");

            entity.Property(e => e.Ge19Codice)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GE19_CODICE");
            entity.Property(e => e.Ge19Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GE19_DESCRIZIONE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
