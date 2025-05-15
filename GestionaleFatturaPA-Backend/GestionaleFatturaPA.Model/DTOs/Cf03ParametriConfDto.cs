using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
    public class Cf03ParametriConfDto
    {
        public Guid Cf03TenantCf01 { get; set; }

        public string Cf03Parametro { get; set; } = null!;

        public string? Cf03Raggruppamento { get; set; }

        public string? Cf03ValoreTesto { get; set; }

        public int? Cf03ValoreInt { get; set; }

        public DateTime? Cf03ValoreData { get; set; }

        public decimal? Cf03ValoreDecimal { get; set; }

        public bool? Cf03ValoreBit { get; set; }
    }
}
