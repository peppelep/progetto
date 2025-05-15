using GestionaleFatturaPa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Model.DTOs
{
    public  class Ge02RuoliDto
    {
        public Guid Ge02Ruolo { get; set; }

        public string Ge02Descrizione { get; set; } = null!;

        public string? Ge02Note { get; set; }

       
    }

}
