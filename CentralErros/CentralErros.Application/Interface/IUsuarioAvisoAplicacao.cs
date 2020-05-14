using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAvisoAplicacao
    {
        UsuarioAvisoViewModel AvisoVisualizado(string idUsuario, int idAviso, bool visualizado);
    }
}
