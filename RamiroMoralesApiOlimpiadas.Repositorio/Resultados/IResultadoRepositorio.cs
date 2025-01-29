using RamiroMoralesApiOlimpiadas.Dto.Integracion;
using RamiroMoralesApiOlimpiadas.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Repositorio.Resultados
{
    public interface IResultadoRepositorio
    {
        IEnumerable<Resultado> ListaResultados();
        DtoRespuesta InsertarResultado(DtoInsertarResultados entidad);
        List<DtoResultadoDeportista> ConsultarResulatdosPorDeportistas(string idDeportista);
    }
}
