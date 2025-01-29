using RamiroMoralesApiOlimpiadas.Infraestructura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Repositorio.Excepciones
{
    public class LogRepositorio : ILogRepositorio
    {
        public LogRepositorio()
        {
        }

        public void InsertarLog(string exepcion)
        {
            using (var context = new OlimpiadasDbContext())
            {
                context.Logs.Add(new Entidades.Entidades.Log
                {
                    DescripcionLog = exepcion
                });
                context.SaveChanges();
            }


        }
    }
}
