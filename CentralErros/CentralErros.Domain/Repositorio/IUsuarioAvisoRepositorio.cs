using CentralErros.Domain.Modelo;

namespace CentralErros.Domain.Repositorio
{
    public interface IUsuarioAvisoRepositorio : IRepositorioBase<UsuarioAviso>
    {
        UsuarioAviso AvisoVisualizado(string idUsuario, int idAviso, bool visualizado);
    }
}
