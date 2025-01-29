using RamiroMoralesApiOlimpiadas.Dto.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio
{
    public interface INeValidacion
    {
        bool ValidarClaveAcceso(Autenticacion request);
    }
}
