using RamiroMoralesApiOlimpiadas.Dto.Integracion;
using RamiroMoralesApiOlimpiadas.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio
{
    public interface INeResultado
    {
        IEnumerable<Resultado> ListaResultadosOlimpiadas();
        DtoRespuesta InsertarResultadoDeportista(DtoInsertarResultados entidad);
        List<DtoResultadoDeportista> BucarDeportistaPorId(string idDeportista);

    }
}
