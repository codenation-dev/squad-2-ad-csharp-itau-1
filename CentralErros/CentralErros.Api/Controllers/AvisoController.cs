using System;
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
    public class AvisoController : ControllerBase
    {
        private readonly IAvisoAplicacao _repo;
        
        public AvisoController(IAvisoAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Aviso
        [HttpGet]
        public ActionResult<IEnumerable<AvisoViewModel>> Get()
        {
            var idUsuario = HttpContext.User.Claims.ToList()[0].Value;
            return Ok(_repo.ObterTodosAvisos(idUsuario));
        }
    }
}