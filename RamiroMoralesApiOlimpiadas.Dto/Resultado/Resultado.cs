using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Resultado
{
    public class Resultado
    {
        public int IdResultado { get; set; }

        public int? IdDeportista { get; set; }

        public string Evento { get; set; } = null!;

        public int Anio { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? PesoLevantado { get; set; }

        public virtual Deportista? IdDeportistaNavigation { get; set; }
    }
}
