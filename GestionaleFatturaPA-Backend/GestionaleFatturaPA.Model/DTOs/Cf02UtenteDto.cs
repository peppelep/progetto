namespace GestionaleFatturaPA.Model.DTOs
{
    public class Cf02UtenteDto
    {
		public Guid Cf02TenantCf01 { get; set; }

		public string Cf02Utente1 { get; set; } = null!;

		public Guid? Cf02RuoloGe02 { get; set; }

		public string? Cf02Password { get; set; }

		public string? Cf02Email { get; set; }

		public string? Cf02Telefono { get; set; }

		public bool? Cf02Fornitori { get; set; }

		public bool? Cf02Clienti { get; set; }

		public bool? Cf02Primanota { get; set; }
		public string? Ge02Descrizione { get; set; }
	}
}


