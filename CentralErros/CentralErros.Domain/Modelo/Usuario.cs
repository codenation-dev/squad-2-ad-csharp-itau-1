using CentralErros.Domain.Repositorio;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CentralErros.Domain.Modelo
{
    public class Usuario : IdentityUser
    {
        public string Role { get; set; }
        public List<UsuarioAviso> UsuariosAvisos { get; set; }
        public List<UsuarioAplicacao> UsuariosAplicacoes { get; set; }
    }
}
