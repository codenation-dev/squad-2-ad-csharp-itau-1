using CentralErros.Data;
using CentralErros.Domain.Modelo;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralErros.Test.Domain
{
    public static class ContextFakeSeeds
    {
        public static Contexto SeedAplicacao(Contexto contexto)
        {
            if (contexto.Aplicacao.Count() > 1) 
                return contexto;
            var aplicacoes = new List<Aplicacao>()
            {
                new Aplicacao(){Descricao = "Ponto de venda Fronte de caixa", Nome = "PDV"},
                new Aplicacao(){Descricao = "Sistema de retaguarda", Nome = "Painel Executivo"},
                new Aplicacao(){Descricao = "Sistema de gestão de projeções", Nome = "Painel de desempenho"},
            };

            var TipoLogs = GerarTiposDeLog();

            contexto.TipoLog.AddRange(TipoLogs);
            contexto.Aplicacao.AddRange(aplicacoes);
            contexto.SaveChanges();

            aplicacoes.ForEach(x =>
            {
                contexto.Entry<Aplicacao>(x).State = EntityState.Detached;
            });
            TipoLogs.ForEach(x =>
            {
                contexto.Entry<TipoLog>(x).State = EntityState.Detached;
            });
            return contexto;

        }

        private static List<TipoLog> GerarTiposDeLog()
        {
            return new List<TipoLog>()
            {
                new TipoLog(){Descricao = "Worning"},
                new TipoLog(){Descricao = "Error"},
                new TipoLog(){Descricao = "Info"},
                new TipoLog(){Descricao = "Fatal"},
            };
        }

        public static Contexto SeedAviso(Contexto contexto)
        {
            if (contexto.Aviso.Count() > 1)
                return contexto;

            var avisos = new List<Aviso>()
            {
                new Aviso(){Data = DateTime.Now, Descricao = "Erro fatal"},
                new Aviso(){Data = DateTime.Now, Descricao = "Worning de aplicacao"},
                new Aviso(){Data = DateTime.Now, Descricao = "Worning de Debug"},
                new Aviso(){Data = DateTime.Now, Descricao = "Info Erros gerais"}
            };

            contexto.Aviso.AddRange(avisos);

            avisos.ForEach(x =>
            {
                contexto.Entry<Aviso>(x).State = EntityState.Detached;
            });

            return contexto;
        }
    }
}
