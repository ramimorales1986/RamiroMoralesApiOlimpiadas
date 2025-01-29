using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using RamiroMoralesApiOlimpiadas.Dto.Autenticacion;
using System.Text;
using RamiroMoralesApiOlimpiadas.Infraestructura.Constantes;
using RamiroMoralesApiOlimpiadas.Negocio.LogicaNegocio;

namespace RamiroMoralesApiOlimpiadas.Controllers
{
    [ApiController]
    [Route("api/RamiroMoralesApiOlimpiadas/[controller]/[action]")]
    public class AutenticacionController : Controller
    {
        private readonly string? _secretKey;
        private readonly INeValidacion _validacion;
        public AutenticacionController(IConfiguration config, INeValidacion validacion)
        {
            _secretKey = config.GetSection("setting").GetSection("secretKey").ToString();
            _validacion = validacion;
        }

        [HttpPost]
        public IActionResult Validar([FromBody] Autenticacion request)
        {
            bool estado = _validacion.ValidarClaveAcceso(request);
            if (estado)
            {
                var keyBytes = Encoding.ASCII.GetBytes(_secretKey!);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Usuario1));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var TokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = TokenHandler.CreateToken(tokenDescriptor);
                string tokenCreado = TokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK,new { token = tokenCreado });
            }
            else{

                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }

        }

    }
}
