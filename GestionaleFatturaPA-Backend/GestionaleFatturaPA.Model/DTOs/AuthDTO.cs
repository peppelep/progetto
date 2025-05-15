using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
	public class AuthDTO
	{
		public bool Error { get; set; }
		public string? ErrorDescription { get; set; }
		public string? Token { get; set; }
		public Guid GuidUtente { get; set; }
		public string Email { get; set; }
		public string Cf { get; set; }
		public string Ruolo { get; set; }
		public string Initials { get; set; }
		public Guid TenantId { get; set; }
	}
}
