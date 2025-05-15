using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf03ParametriConf
{
    public Guid Cf03TenantCf01 { get; set; }

    public string Cf03Parametro { get; set; } = null!;

    public string? Cf03Raggruppamento { get; set; }

    public string? Cf03ValoreTesto { get; set; }

    public int? Cf03ValoreInt { get; set; }

    public DateTime? Cf03ValoreData { get; set; }

    public decimal? Cf03ValoreDecimal { get; set; }

    public bool? Cf03ValoreBit { get; set; }

    public virtual Cf01Tenant Cf03TenantCf01Navigation { get; set; } = null!;
}
