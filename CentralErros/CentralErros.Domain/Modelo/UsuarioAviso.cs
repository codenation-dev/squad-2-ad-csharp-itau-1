using CentralErros.Domain.Repositorio;
using Microsoft.AspNetCore.Identity;

namespace CentralErros.Domain.Modelo
{
    public class UsuarioAviso : IEntity
    {
        public int Id { get; set; }
        public bool Visualizado { get; set; }
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdAviso { get; set; }
        public Aviso Aviso { get; set; }
    }
}
