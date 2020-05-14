using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class AplicacaoRepositorio : RepositorioBase<Aplicacao>, IAplicacaoRepositorio
    {
        public AplicacaoRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public Aplicacao ObterAplicacaoId(int id)
        {
            IQueryable<Aplicacao> aplicacoes = _contexto.Aplicacao
                .Where(x => x.Id == id)
                .Include(x => x.Logs)
                .Include(x => x.UsuariosAplicacoes);

            aplicacoes = aplicacoes.Include(x => x.Logs).ThenInclude(up => up.TipoLog);
            aplicacoes = aplicacoes.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacoes.AsNoTracking().FirstOrDefault();
        }

        public List<Aplicacao> ObterAplicacaoNome(string nome)
        {
            IQueryable<Aplicacao> aplicacoes = _contexto.Aplicacao
                .Where(x => x.Nome.ToUpper().Contains(nome))
                .Include(x => x.Logs)
                .Include(x => x.UsuariosAplicacoes);

            aplicacoes = aplicacoes.Include(x => x.Logs).ThenInclude(up => up.TipoLog);
            aplicacoes = aplicacoes.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacoes.AsNoTracking().ToList();
        }

        public List<Aplicacao> ObterTodosAplicacoes()
        {
            IQueryable<Aplicacao> aplicacoes = _contexto.Aplicacao
                .Include(x => x.Logs)
                .Include(x => x.UsuariosAplicacoes);

            aplicacoes = aplicacoes.Include(x => x.Logs).ThenInclude(up => up.TipoLog);
            aplicacoes = aplicacoes.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacoes.AsNoTracking().ToList();
        }

        public Aplicacao ObterAplicacaoTipoLog(int app_id, int tipolog_id)
        {
            Aplicacao app = (from aplicacao in _contexto.Aplicacao where aplicacao.Id == app_id select aplicacao).FirstOrDefault();
            IQueryable<Log> querylogs = (from log in _contexto.Log where log.IdTipoLog == tipolog_id && log.IdAplicacao == app_id select log);

            List<Log> logs = querylogs.Include(x => x.TipoLog).AsNoTracking().ToList();

            app.Logs = logs;

            return app;
        }

        public Aplicacao Incluir(Aplicacao aplicacao, string idUsuario)
        {
            _contexto.Aplicacao.Add(aplicacao);
            _contexto.SaveChanges();
            _contexto.UsuariosAplicacoes.Add(new UsuarioAplicacao()
            { 
                IdAplicacao = aplicacao.Id,
                IdUsuario = idUsuario
            });
            _contexto.SaveChanges();
            return aplicacao;
        }

        public Aplicacao ObterAplicacaoUsuarios(int idAplicacao)
        {
            IQueryable<Aplicacao> aplicacao = _contexto.Aplicacao
                .Where(x => x.Id == idAplicacao)
                .Include(x => x.UsuariosAplicacoes);

            aplicacao = aplicacao.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacao.AsNoTracking().FirstOrDefault();
        }

        public Aplicacao ObterAplicacaoLogs(int idAplicacao)
        {
            IQueryable<Aplicacao> aplicacao = _contexto.Aplicacao
                .Where(x => x.Id == idAplicacao)
                .Include(x => x.Logs);

            aplicacao = aplicacao.Include(x => x.Logs).ThenInclude(up => up.TipoLog);

            return aplicacao.AsNoTracking().FirstOrDefault();
        }

        public bool VerificaAcessoUsuariosApp(string idUsuario, int idAplicacao)
        {
            var usuarioaplicacao = _contexto.UsuariosAplicacoes
                                     .FirstOrDefault(x => x.IdAplicacao == idAplicacao &&
                                                     x.IdUsuario == idUsuario);
            return usuarioaplicacao != null;
        }
    }
}