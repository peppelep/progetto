using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
	public class AziendaCommonResponse
	{
		public string RagioneSociale { get; set; }
		public string Piva { get; set; }
		public string CodiceFiscale { get; set; }
		public string NREA { get; set; }
		public string Indirizzo { get; set; }
		public string Civico { get; set; }
		public string Comune { get; set; }
		public string Provincia { get; set; }
		public string Nazione { get; set; }
		public string StatoAttivitaDesc { get; set; }
		public string CodiceAteco { get; set; }
		public string DescrizioneAteco { get; set; }
		public string CAP { get; set; }
		public DateTime? DataInizioAttivita { get; set; }
		public string FasciaNumDipendentiISTAT { get; set; }
		public double? UtilePerditaUltimoAnno { get; set; }
		public double? FatturatoUltimoAnno { get; set; }
		public DateTime? UltimoAnno { get; set; }
		public double? UtilePerditaPenultimoAnno { get; set; }
		public double? FatturatoPenultimoAnno { get; set; }
		public DateTime? PenultimoAnno { get; set; }
		public double? UtilePerditaTerzultimoAnno { get; set; }
		public double? FatturatoTerzultimoAnno { get; set; }
		public DateTime? TerzultimoAnno { get; set; }
		public double? Longitudine { get; set; }
		public double? Latitudine { get; set; }
		public DateTime? CacheTimestamp { get; set; }
		[JsonIgnore]
		public bool HasNoContent { get; set; } = false;

	}
}
