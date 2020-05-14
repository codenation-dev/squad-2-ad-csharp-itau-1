using System.Collections.Generic;
using System.Linq;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAvisoController : ControllerBase
    {
        private readonly IUsuarioAvisoAplicacao _repo;
        public UsuarioAvisoController(IUsuarioAvisoAplicacao repo)
        {
            _repo = repo;
        }

        [HttpPut("Visualizado")]
        public ActionResult<UsuarioAvisoViewModel> Visualizado(int idAviso, bool visualizado)
        {
            var idUsuario = HttpContext.User.Claims.ToList()[0].Value;
            var avisoViewModel = _repo.AvisoVisualizado(idUsuario, idAviso, visualizado);
            if (avisoViewModel == null)
                return BadRequest();
            return Ok(avisoViewModel);
        }
    }
}
