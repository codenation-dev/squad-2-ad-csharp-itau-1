using System.Linq;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioAplicacao _app;
        
        public AuthController(IUsuarioAplicacao app)
        {
            _app = app;
        }

        [HttpPost("registrar")]
        public ActionResult<AvisoLoginViewModel> Registrar([FromBody] RegistrarUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var avisoLogin = _app.Registrar(usuario).GetAwaiter().GetResult();

            return Ok(avisoLogin);
        }

        [HttpPost("logar")]
        public ActionResult<AvisoLoginViewModel> Logar([FromBody] LogarUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            return Ok(_app.Logar(usuario).GetAwaiter().GetResult());
        }
    }
}