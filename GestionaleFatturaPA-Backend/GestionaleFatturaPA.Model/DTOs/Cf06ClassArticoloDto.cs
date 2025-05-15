using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
	public class Cf06ClassArticoloDto
	{
		public Guid Cf06TenantCf01 { get; set; }

		public Guid Cf06Classificazione { get; set; }

		public string Cf06Nome { get; set; } = null!;
	}
}
