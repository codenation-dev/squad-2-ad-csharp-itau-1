using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class UsuarioAvisoRepositorio : RepositorioBase<UsuarioAviso>, IUsuarioAvisoRepositorio
    {
        public UsuarioAvisoRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public UsuarioAviso AvisoVisualizado(string idUsuario, int idAviso, bool visualizado)
        {
            var usuarioAviso = _contexto.UsuariosAvisos
                .Where(x => x.IdUsuario == idUsuario && x.IdAviso == idAviso).FirstOrDefault();

            if (usuarioAviso == null)
                return null;

            usuarioAviso.Visualizado = visualizado;

            _contexto.UsuariosAvisos.Update(new UsuarioAviso() 
            { 
                IdUsuario = usuarioAviso.IdUsuario,
                IdAviso = usuarioAviso.IdAviso,
                Visualizado = visualizado
            });
            _contexto.SaveChanges();

            return usuarioAviso;
        }
    }
}
