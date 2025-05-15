namespace GestionaleFatturaPA.Model.DTOs
{
    public class Ge01ComuniDto
    {
        public int Ge01Comune { get; set; }
        public string Ge01Nome { get; set; } = null!;
        public string Ge01Codiceistat { get; set; } = null!;
        public string Ge01Provincia { get; set; } = null!;
        public string Ge01Regione { get; set; } = null!;
        public string Ge01Cap { get; set; } = null!;
        public string Ge01Stato { get; set; } = null!;
        public string Ge02CodiceStato { get; set; } = null!;
    }
}
