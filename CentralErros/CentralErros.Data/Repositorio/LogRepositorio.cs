using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class LogRepositorio : RepositorioBase<Log>, ILogRepositorio
    {
        public LogRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public override Log Incluir(Log log)
        {
            var usuApps = _contexto.UsuariosAplicacoes.Where(x => x.IdAplicacao == log.IdAplicacao)
                .Include(x => x.Aplicacao).ToList();

            if (usuApps.Count() == 0)
                return null;

            var aplicacao = usuApps[0].Aplicacao.Nome;
            var usuAvisos = new List<UsuarioAviso>();
            foreach(var usuApp in usuApps)
            {
                usuAvisos.Add(new UsuarioAviso() { IdUsuario = usuApp.IdUsuario });
            }

            DateTime date = DateTime.Now;
            var tipolog = _contexto.TipoLog.FirstOrDefault(x => x.Id == log.IdTipoLog);
            if (tipolog == null)
                return null;

            var aviso = new Aviso
            {
                Descricao = "AVISO DO TIPO LOG ["+ tipolog.Descricao+"] " +
                            "NA APLICAÇÃO ["+ aplicacao +"]: " + log.Descricao,
                Data = date,
                UsuariosAvisos = usuAvisos
            };
            log.Data = date;
            _contexto.Aviso.Add(aviso);
            _contexto.Log.Add(log);
            _contexto.SaveChanges();
            return log;
        }

        public override Log Alterar(Log log)
        {
            var logRepositorio = _contexto.Log.FirstOrDefault(x => x.Id == log.Id);
            if (logRepositorio == null)
                return null;

            var tipolog = _contexto.TipoLog.FirstOrDefault(x => x.Id == log.IdTipoLog);
            if (tipolog == null)
                return null;

            logRepositorio.Descricao = log.Descricao;
            logRepositorio.IdTipoLog = log.IdTipoLog;
            _contexto.Log.Update(logRepositorio);
            _contexto.SaveChanges();
            return log;
        }

        public Log ObterLogId(int id)
        {
            IQueryable<Log> avisos = _contexto.Log
                .Where(x => x.Id == id)
                .Include(x => x.TipoLog)
                .Include(x => x.Aplicacao);

            return avisos.AsNoTracking().FirstOrDefault();
        }

        public List<Log> ObterTodosLogs()
        {
            IQueryable<Log> avisos = _contexto.Log
                .Include(x => x.TipoLog)
                .Include(x => x.Aplicacao);

            return avisos.AsNoTracking().ToList();
        }

        //Função para obter o id da aplicação que possui mais logs
        public int ObterIdTopAppLog(string filtro)
        {
            var result = new { idAplicacao = 0, qtde = 0 };
            if (filtro.Equals("maior")) {
                result = _contexto.Log
                    .GroupBy(x => x.IdAplicacao)
                    .Select(x => new { idAplicacao = x.Key, qtde = x.Count() })
                    .OrderByDescending(x => x.qtde).FirstOrDefault();
            }
            else
            {
                result = _contexto.Log
                    .GroupBy(x => x.IdAplicacao)
                    .Select(x => new { idAplicacao = x.Key, qtde = x.Count() })
                    .OrderBy(x => x.qtde).FirstOrDefault();
            }
            if (result != null)
                return result.idAplicacao;
            return 0;
        }

        public Dictionary<string, int> TopLogApp(int idAplicacao, out string nomeAplicacao, out string descricaoAplicacao)
        {
            nomeAplicacao = "";
            descricaoAplicacao = "";
            //Os demais são o nome do TipoLog e a quantidade de vezes que ele apareceu no log da aplicação
            var dicionario = new Dictionary<string, int>();
            var app = _contexto.Aplicacao.Where(x => x.Id == idAplicacao).FirstOrDefault();
            if (app != null)
            {
                nomeAplicacao = app.Nome;
                descricaoAplicacao = app.Descricao;

                //Montando uma tabela com a quantidade de logs separadas pelo tipo e de uma aplicação específica
                var query = _contexto.Log
                            .Where(x => x.IdAplicacao == idAplicacao)
                            .GroupBy(x => x.IdTipoLog)
                            .Select(x => new { IdTipoLog = x.Key, qtde = x.Count() }).ToList();

                var dados = (from qry in query
                             join tl in _contexto.TipoLog on qry.IdTipoLog equals tl.Id
                             select new { tl.Descricao, qry.IdTipoLog, qry.qtde }).ToList();

                for (int i = 0; i < dados.Count(); i++)
                {
                    dicionario.Add(dados[i].Descricao, dados[i].qtde);
                }
            }
            return dicionario;
        }
    }
}
