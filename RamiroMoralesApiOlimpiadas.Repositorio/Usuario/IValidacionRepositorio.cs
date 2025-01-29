using RamiroMoralesApiOlimpiadas.Dto.Autenticacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Repositorio.Usuario
{
    public interface IValidacionRepositorio
    {
        bool ValidaUsuario(Autenticacion request);
    }
}
