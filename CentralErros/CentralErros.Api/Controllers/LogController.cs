using System;
using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Log;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogAplicacao _repo;

        public LogController(ILogAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Log
        [HttpGet]
        public IEnumerable<LogViewModel> Get()
        {
            return _repo.ObterTodosLogs();
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public ActionResult<LogViewModel> Get(int? id)
        {
            if (id == null)
                return NoContent();

            return Ok(_repo.ObterLogId(Convert.ToInt32(id)));
        }

        [HttpGet("toplog/filtro")]
        public ActionResult<TopLogAppViewModel> GetTopAppLog(string top)
        {
            if (top == null || (top != "maior" && top != "menor"))
                return NoContent();

            return Ok(_repo.TopLogApp(top));
        }

        [HttpGet("toplog/{id_aplicacao}")]
        public ActionResult<TopLogAppViewModel> GetTopLogAppId(int? id_aplicacao)
        {
            if (id_aplicacao == null)
                return NoContent();

            return Ok(_repo.TopLogAppId(Convert.ToInt32(id_aplicacao)));
        }

        // POST: api/Log
        [HttpPost]
        public ActionResult<RetornoModificacaoLogViewModel> Post([FromBody] CadastroLogViewModel log)
        {
            var logViewModel = _repo.Incluir(log);
            if (logViewModel == null)
                return BadRequest();
            return Ok(logViewModel);
        }

        // PUT: api/Log/5
        [HttpPut]
        public ActionResult<RetornoModificacaoLogViewModel> Put([FromBody] AlteraLogViewModel log)
        {
            var logViewModel = _repo.Alterar(log);
            if (logViewModel == null)
                return BadRequest();
            return Ok(logViewModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<List<LogViewModel>> Delete(int id)
        {
            _repo.Excluir(id);
            return Ok(_repo.ObterTodosLogs());
        }
    }
}
