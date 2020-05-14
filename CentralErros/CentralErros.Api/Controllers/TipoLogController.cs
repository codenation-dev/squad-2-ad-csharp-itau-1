using System;
using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.TipoLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLogController : ControllerBase
    {
        private readonly ITipoLogAplicacao _repo;
        public TipoLogController(ITipoLogAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/TipoLog
        [HttpGet]
        public ActionResult<IEnumerable<TipoLogViewModel>> Get()
        {
            return Ok(_repo.ObterTodosTipoLogs());
        }

        // GET: api/TipoLog/5
        [HttpGet("{id}")]
        public ActionResult<TipoLogViewModel> Get(int id)
        {
            return Ok(_repo.ObterTipoLogId(id));
        }

        [HttpGet("Ocorrencias")]
        public ActionResult<List<OcorrenciaTipoLogViewModel>> GetOcorrenciasTipoLog()
        {
            return Ok(_repo.OcorrenciasTipoLog());
        }

        // POST: api/TipoLog
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<TipoLogViewModel> Post([FromBody] CadastroTipoLogViewModel tipoLog)
        {
            var tipoLogViewModel = _repo.Incluir(tipoLog);
            return Ok(tipoLogViewModel);
        }

        // PUT: api/TipoLog/5
        [Authorize(Roles = "admin")]
        [HttpPut]
        public ActionResult<TipoLogViewModel> Put([FromBody] AlteraTipoLogViewModel tipoLog)
        {
            var tipoLogViewModel = _repo.Alterar(tipoLog);
            return Ok(tipoLogViewModel);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult<List<TipoLogViewModel>> Delete(int id)
        {
            _repo.Excluir(id);
            return Ok(_repo.ObterTodosTipoLogs());
        }
    }
}