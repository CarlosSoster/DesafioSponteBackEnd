using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponteBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using SponteBackEnd.Services;
using SponteBackEnd.Repositories;

namespace SponteBackEnd.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            var usuario = UsuarioRepositorio.Get(model.Nome, model.Senha);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos"});
            }

            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";

            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}