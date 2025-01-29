using RamiroMoralesApiOlimpiadas.Dto.Integracion;
using RamiroMoralesApiOlimpiadas.Entidades.Entidades;
using RamiroMoralesApiOlimpiadas.Infraestructura.Constantes;
using RamiroMoralesApiOlimpiadas.Repositorio.Resultados;

namespace RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio
{
    public class NeResultado : INeResultado
    {
        private readonly IResultadoRepositorio? _neResultado;
        private readonly INeLog _log;
        public NeResultado(IResultadoRepositorio neResultado, INeLog log)
        {

            _neResultado = neResultado;
            _log = log;
        }

        public IEnumerable<Resultado> ListaResultadosOlimpiadas()
        {
            try
            {
                var resultados = _neResultado!.ListaResultados();
                return resultados;
            }
            catch (Exception ex)
            {
                _log.GuardarLog(ex.Message);
                return Enumerable.Empty<Resultado>();
            }
        }
        public List<DtoResultadoDeportista> BucarDeportistaPorId(string idDeportista)
        {
            try
            {
                var resultados = _neResultado!.ConsultarResulatdosPorDeportistas(idDeportista);
                return resultados;
            }
            catch (Exception ex)
            {
                _log.GuardarLog(ex.Message);
                return new List<DtoResultadoDeportista>();
            }
        }




        public DtoRespuesta InsertarResultadoDeportista(DtoInsertarResultados entidad)
        {
            try
            {
                var respuesta = _neResultado!.InsertarResultado(entidad);
                if (respuesta.Codigo.Equals(CConstante.Codigo.CodigoFallo))
                    _log.GuardarLog(respuesta.Mensaje);

                return respuesta;

            }
            catch (Exception ex)
            {
                _log.GuardarLog(ex.Message);
                return new DtoRespuesta();
            }
        }

        public List<DtoNumeroIntentos> NumeroIntentosDeportistas()
        {
            try
            {
                var resultados = _neResultado!.NumeroDeIntentos();
                return resultados;
            }
            catch (Exception ex)
            {
                _log.GuardarLog(ex.Message);
                return new List<DtoNumeroIntentos>();
            }
        }

    }
}
