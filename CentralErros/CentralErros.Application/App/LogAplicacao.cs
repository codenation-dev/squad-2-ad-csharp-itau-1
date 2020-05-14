using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Log;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class LogAplicacao : ILogAplicacao
    {
        private readonly ILogRepositorio _repo;
        private readonly IMapper _mapper;

        public LogAplicacao(ILogRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public RetornoModificacaoLogViewModel Alterar(AlteraLogViewModel entity)
        {
            var logViewModel = _mapper.Map<RetornoModificacaoLogViewModel>(_repo.Alterar(_mapper.Map<Log>(entity)));
            return logViewModel;
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public RetornoModificacaoLogViewModel Incluir(CadastroLogViewModel entity)
        {
            var logViewModel = _mapper.Map<RetornoModificacaoLogViewModel>(_repo.Incluir(_mapper.Map<Log>(entity)));
            return logViewModel;
        }

        public LogViewModel ObterLogId(int id)
        {
            return _mapper.Map<LogViewModel>(_repo.ObterLogId(id));
        }

        public List<LogViewModel> ObterTodosLogs()
        {
            return _mapper.Map<List<LogViewModel>>(_repo.ObterTodosLogs());
        }

        private TopLogAppViewModel ObterInfoTopLogViewModel(int idAplicacao)
        {
            var toplog = new TopLogAppViewModel();
            toplog.logs = new List<QtdeTipoLogViewModel>();

            string nomeAplicacao = "";
            string descricaoAplicacao = "";
            int totalLogs = 0;

            Dictionary<string, int> dicionario = _repo.TopLogApp(idAplicacao, out nomeAplicacao, out descricaoAplicacao);
            toplog.IdAplicacao = idAplicacao;
            toplog.Nome = nomeAplicacao;
            toplog.Descricao = descricaoAplicacao;
            foreach (var dic in dicionario)
            {
                totalLogs += dic.Value;
                toplog.logs.Add(new QtdeTipoLogViewModel() { QtdeLogs = dic.Value, TipoLog = dic.Key });
            }
            toplog.totalLogs = totalLogs;

            return toplog;
        }

        public Object TopLogApp(string filtro)
        {
            
            int idAplicacao = _repo.ObterIdTopAppLog(filtro);
            if (idAplicacao == 0)
            {
                return new { Aviso = "Não há registros de logs no sistema" };
            }
            else
            {                
                return ObterInfoTopLogViewModel(idAplicacao);
            }
        }

        public Object TopLogAppId(int id_aplicacao)
        {
            var toplog = ObterInfoTopLogViewModel(id_aplicacao);
            if (toplog.Nome != "")
                return toplog;


            return new { Aviso = "Não há registro de aplicação com o ID " + id_aplicacao };
        }
    }
}
