using System.Collections.Generic;
using System.Linq;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.UsuarioAplicacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAplicacaoController : ControllerBase
    {
        private readonly IUsuarioAplicacaoAplicacao _repo;
        public UsuarioAplicacaoController(IUsuarioAplicacaoAplicacao repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<UsuarioAplicacaoViewModel> Post([FromBody] ModificaViewModel_UsuarioAplicacao usuarioAplicacao)
        {
            var idUsuario = HttpContext.User.Claims.ToList()[0].Value;
            var usuAppViewModel = _repo.VinculaUsuarioAplicacao(usuarioAplicacao, idUsuario);
            if (usuAppViewModel == null)
                return BadRequest();
            return Ok(usuAppViewModel);
        }

        [HttpDelete]
        public ActionResult<string> Delete(ModificaViewModel_UsuarioAplicacao usuarioAplicacao)
        {
            var idUsuario = HttpContext.User.Claims.ToList()[0].Value;
            var excluido = _repo.ExcluirUsuarioAplicacao(usuarioAplicacao, idUsuario);
            if (!excluido)
                return BadRequest();
            return Ok("Registro com aplicação excluída com sucesso!");
        }
    }
}
