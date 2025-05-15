using GestionaleFatturaPa.Data.Entities;

namespace GestionaleFatturaPA.Model.DTOs
{
    public class Cf07NumerazioneDto
    {
        public Guid Cf07TenantCf01 { get; set; }

        public int Cg07Anno { get; set; }

        public int Cg07CausaleGe10 { get; set; }

        public string Cf07Serie { get; set; } = null!;

        public int Cf07Numero { get; set; }
    }
}


