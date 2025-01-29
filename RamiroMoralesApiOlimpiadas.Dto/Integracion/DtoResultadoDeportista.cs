using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Integracion
{
    public class DtoResultadoDeportista
    {
        public string Pais { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public decimal Peso { get; set; }
    }
}
