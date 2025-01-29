using RamiroMoralesApiOlimpiadas.Repositorio.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio
{
    public class NeLog : INeLog
    {
        private readonly ILogRepositorio _logRepositorio;
        public NeLog(ILogRepositorio logRepositorio)
        {
            _logRepositorio = logRepositorio;
        }


        public void GuardarLog(string excepcion)
        {
            _logRepositorio.InsertarLog(excepcion);
        }



    }
}
