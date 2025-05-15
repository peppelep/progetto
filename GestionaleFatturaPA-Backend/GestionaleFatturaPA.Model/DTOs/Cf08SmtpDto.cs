using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
    public class Cf08SmtpDto
    {
        public Guid Cf08TenantCf01 { get; set; }

        public string? Cf08Email { get; set; }

        public string? Cf08Mittente { get; set; }

        public string? Cf08Utente { get; set; }

        public string? Cf08Password { get; set; }

        public string? Cf08ServerSmtp { get; set; }

        public int? Cf08Porta { get; set; }

        public string? Cf08Sicurezza { get; set; }
    }
}
