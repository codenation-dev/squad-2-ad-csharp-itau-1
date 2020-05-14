using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.TipoLog;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class TipoLogAplicacao : ITipoLogAplicacao
    {
        private readonly ITipoLogRepositorio _repo;
        private readonly IMapper _mapper;

        public TipoLogAplicacao(ITipoLogRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public TipoLogViewModel Alterar(AlteraTipoLogViewModel entity)
        {
            var tipoLog = _repo.Alterar(_mapper.Map<TipoLog>(entity));
            return _mapper.Map<TipoLogViewModel>(tipoLog);
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public TipoLogViewModel Incluir(CadastroTipoLogViewModel entity)
        {
            var tipoLog = _repo.Incluir(_mapper.Map<TipoLog>(entity));
            return _mapper.Map<TipoLogViewModel>(tipoLog);
        }

        public TipoLogViewModel ObterTipoLogId(int id)
        {
            return _mapper.Map<TipoLogViewModel>(_repo.ObterTipoLogId(id));
        }

        public List<TipoLogViewModel> ObterTodosTipoLogs()
        {
            return _mapper.Map<List<TipoLogViewModel>>(_repo.ObterTodosTipoLogs());
        }

        public List<OcorrenciaTipoLogViewModel> OcorrenciasTipoLog()
        {
            return _mapper.Map<List<OcorrenciaTipoLogViewModel>>(_repo.OcorrenciasTipoLog());
        }
    }
}