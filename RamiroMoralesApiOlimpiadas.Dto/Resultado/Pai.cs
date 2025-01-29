using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Resultado
{
    public class Pai
    {
        public int IdPais { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Deportista> Deportista { get; set; } = new List<Deportista>();
    }
}
