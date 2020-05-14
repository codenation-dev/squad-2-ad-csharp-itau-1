using CentralErros.Domain.DTO;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class TipoLogRepositorio : RepositorioBase<TipoLog>, ITipoLogRepositorio
    {
        public TipoLogRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public TipoLog ObterTipoLogId(int id)
        {
            IQueryable<TipoLog> tipoLog = _contexto.TipoLog
                .Where(x => x.Id == id)
                .Include(x => x.Logs);

            return tipoLog.AsNoTracking().FirstOrDefault();
        }

        public List<TipoLog> ObterTodosTipoLogs()
        {
            IQueryable<TipoLog> tipoLog = _contexto.TipoLog
                .Include(x => x.Logs);

            return tipoLog.AsNoTracking().ToList();
        }

        public List<OcorrenciaTipoLogDTO> OcorrenciasTipoLog()
        {
            var query = _contexto.Log
                            .GroupBy(x => x.IdTipoLog)
                            .Select(x => new { IdTipoLog = x.Key, QtdeOcorrencia = x.Count() }).ToList();

            var dados = (from qry in query
                         join tl in _contexto.TipoLog on qry.IdTipoLog equals tl.Id
                         select new OcorrenciaTipoLogDTO
                         {
                             IdTipoLog = qry.IdTipoLog,
                             Descricao = tl.Descricao,
                             QtdeOcorrencia = qry.QtdeOcorrencia
                         }).ToList();

            return dados;
        }
    }
}