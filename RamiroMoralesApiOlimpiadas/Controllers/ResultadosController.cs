using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RamiroMoralesApiOlimpiadas.Dto.Integracion;
using RamiroMoralesApiOlimpiadas.Entidades.Entidades;
using RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio;



namespace RamiroMoralesApiOlimpiadas.Controllers
{
    [ApiController]
    [Route("api/RamiroMoralesApiOlimpiadas/[controller]/[action]")]
    [Authorize]
    public class ResultadosController : Controller
    {
        private readonly INeResultado _neResultado;
        public ResultadosController(INeResultado neResultado)
        {
            _neResultado = neResultado;
        }        
        [HttpGet]
        public IActionResult Get()
        {
            var respuesta = _neResultado.ListaResultadosOlimpiadas();
            return Ok(respuesta);
        }
        [HttpPost]
        public IActionResult AgregarResultado(DtoInsertarResultados entidad)
        {
            var respuesta =_neResultado.InsertarResultadoDeportista(entidad);
            return Ok(respuesta); 
        }

        [HttpPost]
        public IActionResult BuscarResultadoDeportista(string id)
        {
            var respuesta = _neResultado.BucarDeportistaPorId(id);
            return Ok(respuesta);
        }


    }
}
