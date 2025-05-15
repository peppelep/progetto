using System;
using System.Collections.Generic;

namespace GestionaleFatturaPa.Data.Entities;

public partial class Cf08Smtp
{
    public Guid Cf08TenantCf01 { get; set; }

    public string? Cf08Email { get; set; }

    public string? Cf08Mittente { get; set; }

    public string? Cf08Utente { get; set; }

    public string? Cf08Password { get; set; }

    public string? Cf08ServerSmtp { get; set; }

    public int? Cf08Porta { get; set; }

    public string? Cf08Sicurezza { get; set; }

    public virtual Cf01Tenant Cf08TenantCf01Navigation { get; set; } = null!;
}
