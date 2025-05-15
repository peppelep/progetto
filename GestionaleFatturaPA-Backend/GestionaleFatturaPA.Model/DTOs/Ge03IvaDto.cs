namespace GestionaleFatturaPA.Model.DTOs
{
    public class Ge03IvaDto
    {
		public int Ge03CodiceIva { get; set; }

		public string Ge03Descrizione { get; set; } = null!;

		public decimal Ge03Iva1 { get; set; }

		public decimal Ge03PercIndetraibilita { get; set; }

		public string Ge03CodiceFatturapa { get; set; } = null!;
	}
}


