using RamiroMoralesApiOlimpiadas.Dto.Autenticacion;
using RamiroMoralesApiOlimpiadas.Infraestructura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Repositorio.Usuario
{
    public class ValidacionRepositorio : IValidacionRepositorio
    {

        public ValidacionRepositorio()
        {
        }

        public bool ValidaUsuario(Autenticacion request)
        {
            bool status = false;
            using (var context = new OlimpiadasDbContext())
            {
                var existe = context.Usuarios.Where(m => m.Usuario1 == request.Usuario1 && m.Clave == request.Clave).Count();
                if (existe > 0)
                {
                    status = true;
                    context.Dispose();
                }

                return status;
            }
        }

    }
}
