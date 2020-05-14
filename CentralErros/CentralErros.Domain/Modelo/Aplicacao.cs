using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Domain.Modelo
{
    public class Aplicacao : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<UsuarioAplicacao> UsuariosAplicacoes { get; set; }
        public List<Log> Logs { get; set; }
    }
}
