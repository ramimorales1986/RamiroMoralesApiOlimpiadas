using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Integracion
{
    public class DtoInsertarResultados
    {

        public int? IdDeportista { get; set; }

        public string Evento { get; set; } = null!;

        public int Anio { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? PesoLevantado { get; set; }
    }
}
