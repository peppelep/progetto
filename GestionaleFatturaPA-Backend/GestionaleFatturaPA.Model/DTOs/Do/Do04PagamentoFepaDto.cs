namespace GestionaleFatturaPA.Model.DTOs.Do
{
    public class Do04PagamentoFepaDto
    {
        public Guid Do04TenantCf01 { get; set; }

        public Guid Do04Keydoc { get; set; }

        public int Do04Rigaid { get; set; }

        public string? Do04PagFepaGe15 { get; set; }

        public decimal? Do04Importo { get; set; }

        public DateOnly? Do04Datarifpag { get; set; }

        public DateOnly? Do04Datascadenza { get; set; }

        public string? Do04Iban { get; set; }

        public string? Do04Banca { get; set; }

        public string? Do04Abi { get; set; }

        public string? Do04Cab { get; set; }
    }
}


