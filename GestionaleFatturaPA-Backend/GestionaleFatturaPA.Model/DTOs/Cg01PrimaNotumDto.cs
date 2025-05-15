namespace GestionaleFatturaPA.Model.DTOs
{
    public class Cg01PrimaNotumDto
    {
        public Guid Cg01TenantCf01 { get; set; }
        public Guid Cg01Keypn { get; set; }
        public bool? Cg01Deleted { get; set; }
        public string? Cg01CliforAn02 { get; set; }
        public Guid? Cg01AnagraficaAn02 { get; set; }
        public Guid? Cg01ContoCf04 { get; set; }
        public string? Cg01Note { get; set; }
        public decimal? Cg01Entrate { get; set; }
        public decimal? Cg01Uscite { get; set; }
    }
}

