using CentralErros.Domain.Repositorio;
using Microsoft.AspNetCore.Identity;

namespace CentralErros.Domain.Modelo
{
    public class UsuarioAplicacao : IEntity
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdAplicacao { get; set; }
        public Aplicacao Aplicacao { get; set; }
    }
}
