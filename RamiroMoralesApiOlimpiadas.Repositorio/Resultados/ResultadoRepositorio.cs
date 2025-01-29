using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RamiroMoralesApiOlimpiadas.Dto.Integracion;
using RamiroMoralesApiOlimpiadas.Entidades.Entidades;
using RamiroMoralesApiOlimpiadas.Infraestructura.Constantes;
using RamiroMoralesApiOlimpiadas.Infraestructura.Contextos;
using System.Collections.Generic;

namespace RamiroMoralesApiOlimpiadas.Repositorio.Resultados
{
    public class ResultadoRepositorio : IResultadoRepositorio
    {
        public ResultadoRepositorio()
        {
        }
        public IEnumerable<Resultado> ListaResultados()
        {
            using (var context = new OlimpiadasDbContext())
            {
                return context.Resultados.ToList();
            }
        }


        public List<DtoResultadoDeportista> ConsultarResulatdosPorDeportistas(string idDeportista)
        {
            using (var context = new OlimpiadasDbContext())
            {
                var clientIdParameter = new SqlParameter("@idDeportista", idDeportista);

                var result = context.Database.SqlQueryRaw<DtoResultadoDeportista>("MejoresPesosPorIdDeportista @idDeportista", clientIdParameter)
                    .ToList();
                return result;
            }
        }
        public DtoRespuesta InsertarResultado(DtoInsertarResultados entidad)
        {
            DtoRespuesta respuesta = new DtoRespuesta();
            try
            {
                using (var context = new OlimpiadasDbContext())
                {
                    var numeroRegistros = context.Resultados.Where(m => m.IdDeportista == entidad.IdDeportista && m.Anio == entidad.Anio
                    && m.Evento == entidad.Evento && m.IdCategoria == entidad.IdCategoria).Count();
                    if (numeroRegistros < 3)
                    {
                        context.Resultados.Add(new Resultado
                        {
                            IdCategoria = entidad.IdCategoria,
                            IdDeportista = entidad.IdDeportista,
                            Anio = entidad.Anio,
                            Evento = entidad.Evento,
                            PesoLevantado = entidad.PesoLevantado
                        });
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Dispose();
                        return respuesta = new()
                        {
                            Codigo = CConstante.Codigo.CodigoExitoso,
                            Mensaje = CConstante.Mensajes.MensajeIntentos
                        };
                    }
                }

                return respuesta = new()
                {
                    Codigo = CConstante.Codigo.CodigoExitoso,
                    Mensaje = CConstante.Mensajes.MensajeExitoso
                };
            }
            catch (Exception ex)
            {

                return respuesta = new()
                {
                    Codigo = CConstante.Codigo.CodigoFallo,
                    Mensaje = ex.Message.ToString()
                };

            }
        }


        public List<DtoNumeroIntentos> NumeroDeIntentos()
        {            
            using (var context = new OlimpiadasDbContext())
            {
                var result = context.Database.SqlQueryRaw<DtoNumeroIntentos>("NumeroIntentos").ToList();
                return result;
            }
        }

    }
}
