using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.UsuarioAplicacao;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class UsuarioAplicacaoAplicacao : IUsuarioAplicacaoAplicacao
    {
        private readonly IUsuarioAplicacaoRepositorio _repo;
        private readonly IMapper _mapper;

        public UsuarioAplicacaoAplicacao(IUsuarioAplicacaoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public bool ExcluirUsuarioAplicacao(ModificaViewModel_UsuarioAplicacao usuarioAplicacao, 
            string idUsuario)
        {
            return _repo.ExcluirUsuarioAplicacao(usuarioAplicacao.idAplicacao, idUsuario);
        }

        public UsuarioAplicacaoViewModel VinculaUsuarioAplicacao(ModificaViewModel_UsuarioAplicacao usuarioAplicacao, 
            string idUsuario)
        {
            var usuAplicacaoViewModel = _mapper.Map<UsuarioAplicacaoViewModel>(
                _repo.VinculaUsuarioAplicacao(usuarioAplicacao.idAplicacao, idUsuario));
            return usuAplicacaoViewModel;
        }
    }
}