using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
	public class An02AnagraficaDto
	{
		public Guid An02TenantCf01 { get; set; }

		public string An02Clifor { get; set; }

		public Guid? An02Anagrafica1 { get; set; }

		public bool? An02Deleted { get; set; }

		public string? An02CodiceInterno { get; set; }

		public string? An02Stato { get; set; }

		public string? An02Ragsoc { get; set; }

		public string? An02Codicesdi { get; set; }

		public string? An02Tipologia { get; set; }

		public string? An02Comune { get; set; }

		public string? An02IndirizzoPec { get; set; }

		public string? An02Referente { get; set; }

		public string? An02Cap { get; set; }

		public string? An02Provincia { get; set; }

		public string? An02Telefono { get; set; }

		public string An02Partitaiva { get; set; }

		public string An02CoiceFiscale { get; set; }

		public string? An02NoteIndirizzo { get; set; }

		public string? An02Note { get; set; }

		public int? An02IvapredefGe03 { get; set; }

		public decimal? An02Sconto { get; set; }

		public int? An02GiorniPag { get; set; }

		public string? An02Periodo { get; set; }

		public Guid? An02PagamentoCf05 { get; set; }

		public string? An02Iban { get; set; }

		public string? An02IndirizzoSpedizione { get; set; }

		public string? An02LetteraIntento { get; set; }

		public DateTime? An02DataLettera { get; set; }

		public string? An02Numerolettera { get; set; }

		public string? An02UserCreateCf02 { get; set; } = null!;

		public DateTime? An02DataCreate { get; set; }

		public string? An02UserUpdateCf02 { get; set; }

		public DateTime? An02DataUpdate { get; set; }
        public string? An02UserCreateCf02Email { get; set; }
        public string? An02UserUpdateCf02Email { get; set; }
    }
}
