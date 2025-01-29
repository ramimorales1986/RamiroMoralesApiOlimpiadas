using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Resultado
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Deportista> IdDeportista { get; set; } = new List<Deportista>();
    }
}
