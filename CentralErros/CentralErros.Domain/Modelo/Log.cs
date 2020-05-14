using CentralErros.Domain.Repositorio;
using System;

namespace CentralErros.Domain.Modelo
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoLog { get; set; }
        public TipoLog TipoLog { get; set; }
        public int IdAplicacao { get; set; }
        public Aplicacao Aplicacao { get; set; }
    }
}
