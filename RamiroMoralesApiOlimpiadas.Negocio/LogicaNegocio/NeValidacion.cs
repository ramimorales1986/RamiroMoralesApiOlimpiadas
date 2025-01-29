using RamiroMoralesApiOlimpiadas.Dto.Autenticacion;
using RamiroMoralesApiOlimpiadas.Repositorio.Log;
using RamiroMoralesApiOlimpiadas.Repositorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio
{
    public class NeValidacion: INeValidacion
    {
        private readonly IValidacionRepositorio _validacionRepositorio;

        public NeValidacion(IValidacionRepositorio validacionRepositorio)
        {
            _validacionRepositorio = validacionRepositorio;
        }


        public bool ValidarClaveAcceso(Autenticacion request)
        {
            return _validacionRepositorio.ValidaUsuario(request);
        }

    }
}
