using System;
using System.Collections.Generic;
using System.Linq;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Usuario;
using CentralErros.Application.ViewModel.Usuario.UsuarioAviso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _repo;

        public UsuarioController(IUsuarioAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/usuario/usuario-apps
        [HttpGet("aplicacoes")]
        public ActionResult<UsuarioAppsViewModel_Usuario> GetUsuarioApps()
        {
            return Ok(_repo.ObterUsuarioAplicacoes(HttpContext.User.Claims.ToList()[0].Value));
        }

        // GET: api/usuario/usuario-avisos
        [HttpGet("avisos")]
        public ActionResult<UsuarioAvisosViewModel_Usuario> GetUsuarioAvisos()
        {
            return Ok(_repo.ObterUsuarioAvisos(HttpContext.User.Claims.ToList()[0].Value));
        }

        // GET: api/usuario/registro
        [HttpGet("registro")]
        public ActionResult<UsuarioViewModel> GetRegistro()
        {
            return Ok(_repo.ObterUsuarioId(HttpContext.User.Claims.ToList()[0].Value));
        }

        //PUT: api/Usuario
        [HttpPut]
        public ActionResult<UsuarioViewModel> Put([FromBody] AlterarUsuarioViewModel usuario)
        {
            string Id = HttpContext.User.Claims.ToList()[0].Value;
            _repo.Alterar(usuario, Id);
            return Ok(_repo.ObterUsuarioId(Id));
        }

        // DELETE: api/Usuario
        [HttpDelete]
        public ActionResult<string> Delete()
        {
            var excluido = _repo.Deletar(HttpContext.User.Claims.ToList()[0].Value);
            if (excluido)
                return Ok("Usuário excluído com sucesso!");
            return BadRequest("Problemas ao excluir usuário");
        }
    }
}
