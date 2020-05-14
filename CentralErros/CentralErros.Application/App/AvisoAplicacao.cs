using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class AvisoAplicacao : IAvisoAplicacao
    {
        private readonly IAvisoRepositorio _repo;
        private readonly IMapper _mapper;

        public AvisoAplicacao(IAvisoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(AvisoViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Aviso>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(AvisoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Aviso>(entity));
        }

        public List<AvisoViewModel> ObterTodosAvisos(string idUsuario)
        {
            var avisoViewModel = _mapper.Map<List<AvisoViewModel>>(_repo.ObterTodosAvisos(idUsuario));
            return avisoViewModel;
        }
    }
}