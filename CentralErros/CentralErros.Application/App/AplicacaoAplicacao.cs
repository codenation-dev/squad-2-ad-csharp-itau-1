using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Aplicacao;
using CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs;
using CentralErros.Application.ViewModel.Aplicacao.UsuarioAplicacao;
using CentralErros.Application.ViewModel.Usuario;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class AplicacaoAplicacao : IAplicacaoAplicacao
    {
        private readonly IAplicacaoRepositorio _repo;
        private readonly IMapper _mapper;

        public AplicacaoAplicacao(IAplicacaoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(AplicacaoSimplesViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Aplicacao>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public AplicacaoSimplesViewModel Incluir(CadastroAplicacaoViewModel entity, string idUsuario)
        {
            return _mapper.Map<AplicacaoSimplesViewModel>(
                _repo.Incluir(_mapper.Map<Aplicacao>(entity), idUsuario));
        }

        public AplicacaoSimplesViewModel ObterAplicacaoId(int id)
        {
            return _mapper.Map<AplicacaoSimplesViewModel>(_repo.ObterAplicacaoId(id));
        }

        public List<AplicacaoSimplesViewModel> ObterAplicacaoNome(string nome)
        {
            return _mapper.Map<List<AplicacaoSimplesViewModel>>(_repo.ObterAplicacaoNome(nome));
        }

        public AplicacaoLogsViewModel_Aplicacao ObterAplicacaoTipoLog(int app_id, int tipolog_id)
        {
            return _mapper.Map<AplicacaoLogsViewModel_Aplicacao>(_repo.ObterAplicacaoTipoLog(app_id, tipolog_id));
        }

        public AplicacaoUsuarioViewModel_Aplicacao ObterAplicacaoUsuarios(int idAplicacao)
        {
            var aplicacaoViewModel = new AplicacaoUsuarioViewModel_Aplicacao()
            {
                IdAplicacao = 0,
                Nome = "",
                Usuarios = new List<UsuarioViewModel_Aplicacao>()
            };

            var aplicacao = _repo.ObterAplicacaoUsuarios(idAplicacao);
            if(aplicacao != null)
            {
                aplicacaoViewModel.IdAplicacao = aplicacao.Id;
                aplicacaoViewModel.Nome = aplicacao.Nome;
                foreach(var usuarioAplicacao in aplicacao.UsuariosAplicacoes)
                {
                    aplicacaoViewModel.Usuarios.Add(new UsuarioViewModel_Aplicacao()
                    {
                        IdUsuario = usuarioAplicacao.Usuario.Id,
                        Nome = usuarioAplicacao.Usuario.UserName,
                        Email = usuarioAplicacao.Usuario.Email,
                        Role = usuarioAplicacao.Usuario.Role
                    });
                }
            }
            return aplicacaoViewModel;
        }

        public AplicacaoLogsViewModel_Aplicacao ObterAplicacaoLogs(int idAplicacao)
        {
            var aplicacaoViewModel = _mapper.Map<AplicacaoLogsViewModel_Aplicacao>(
                _repo.ObterAplicacaoLogs(idAplicacao));

            return aplicacaoViewModel;
        }

        public List<AplicacaoSimplesViewModel> ObterTodosAplicacoes()
        {
            return _mapper.Map<List<AplicacaoSimplesViewModel>>(_repo.ObterTodosAplicacoes());
        }

        public bool VerificaAcessoUsuariosApp(string idUsuario, int idAplicacao)
        {
            return _repo.VerificaAcessoUsuariosApp(idUsuario, idAplicacao);
        }
    }
}