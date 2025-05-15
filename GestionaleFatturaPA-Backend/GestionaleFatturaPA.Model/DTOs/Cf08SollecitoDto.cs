using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
    public class Cf08SollecitoDto
    {
        public Guid Cf08TenantCf01 { get; set; }

        public Guid? Cf08Sollecito1 { get; set; }

        public string? Cf08Oggetto { get; set; }

        public string? Cf08Messaggio { get; set; }

        public decimal? Cf08Importida { get; set; }

        public string? Cf08Inviail { get; set; }

        public int? Cf08Giorni { get; set; }

        public bool? Cf08FlgProforma { get; set; }

        public bool? Cf08FlgFatture { get; set; }

        public bool? Cf08FlgRicevute { get; set; }
    }
}
