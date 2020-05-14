using CentralErros.Domain.Modelo;
using System.Collections.Generic;

namespace CentralErros.Domain.Repositorio
{
    public interface IUsuarioAplicacaoRepositorio : IRepositorioBase<UsuarioAplicacao>
    {
        UsuarioAplicacao VinculaUsuarioAplicacao(int idAplicacao, string idUsuario);
        bool ExcluirUsuarioAplicacao(int idAplicacao, string idUsuario);
    }
}
