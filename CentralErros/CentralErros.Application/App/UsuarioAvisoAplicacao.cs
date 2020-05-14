using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class UsuarioAvisoAplicacao : IUsuarioAvisoAplicacao
    {
        private readonly IUsuarioAvisoRepositorio _repo;
        private readonly IMapper _mapper;

        public UsuarioAvisoAplicacao(IUsuarioAvisoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(UsuarioAvisoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<UsuarioAviso>(entity));
        }

        public UsuarioAvisoViewModel AvisoVisualizado(string idUsuario, int idAviso, bool visualizado)
        {
            var usuarioAviso = _mapper.Map<UsuarioAvisoViewModel>(
                _repo.AvisoVisualizado(idUsuario, idAviso, visualizado));
            return usuarioAviso;
        }
    }
}
