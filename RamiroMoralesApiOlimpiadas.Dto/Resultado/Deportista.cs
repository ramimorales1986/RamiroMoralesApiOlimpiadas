using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Dto.Resultado
{
    public class Deportista
    {
        public int IdDeportista { get; set; }

        public string Nombre { get; set; } = null!;

        public int? IdPais { get; set; }

        public virtual Pai? IdPaisNavigation { get; set; }

        public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();

        public virtual ICollection<Categoria> IdCategoria { get; set; } = new List<Categoria>();
    }
}
