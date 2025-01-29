using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Integracion
{
    public class DtoNumeroIntentos
    {
        public int categoria { get; set; }
        public string nombre { get; set; } = null!;
        public string descripcion { get; set; } = null!;
        public int id_deportista { get; set; }
        public int intentos { get; set; }

    }
}
