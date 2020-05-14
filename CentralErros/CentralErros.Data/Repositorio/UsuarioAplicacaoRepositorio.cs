using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class UsuarioAplicacaoRepositorio : RepositorioBase<UsuarioAplicacao>, IUsuarioAplicacaoRepositorio
    {
        public UsuarioAplicacaoRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public bool ExcluirUsuarioAplicacao(int idAplicacao, string idUsuario)
        {
            var usuAplicacao = _contexto.UsuariosAplicacoes
                .FirstOrDefault(x => x.IdAplicacao == idAplicacao && x.IdUsuario == idUsuario);

            if (usuAplicacao == null)
                return false;

            _contexto.UsuariosAplicacoes.Remove(usuAplicacao);
            _contexto.SaveChanges();

            return true;
        }

        public UsuarioAplicacao VinculaUsuarioAplicacao(int idAplicacao, string idUsuario)
        {
            var aplicacao = _contexto.Aplicacao.FirstOrDefault(x => x.Id == idAplicacao);
            if (aplicacao == null)
                return null;

            _contexto.UsuariosAplicacoes.Add(new UsuarioAplicacao()
            {
                IdAplicacao = idAplicacao,
                IdUsuario = idUsuario
            });
            _contexto.SaveChanges();

            var usuarioAplicacao = _contexto.UsuariosAplicacoes
                .Where(x => x.IdAplicacao == idAplicacao && x.IdUsuario == idUsuario)
                .Include(x => x.Aplicacao)
                .Include(x => x.Usuario).FirstOrDefault();

            return usuarioAplicacao;
        }
    }
}