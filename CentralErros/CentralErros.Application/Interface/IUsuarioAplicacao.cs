using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Usuario;
using CentralErros.Application.ViewModel.Usuario.UsuarioAviso;
using System.Threading.Tasks;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAplicacao
    {
        UsuarioAppsViewModel_Usuario ObterUsuarioAplicacoes(string idUsuario);
        UsuarioAvisosViewModel_Usuario ObterUsuarioAvisos(string idUsuario);
        UsuarioViewModel ObterUsuarioId(string idUsuario);
        UsuarioViewModel Alterar(AlterarUsuarioViewModel usuario, string id);
        bool Deletar(string Id);
        Task<AvisoLoginViewModel> Registrar(RegistrarUsuarioViewModel usuario);
        Task<AvisoLoginViewModel> Logar(LogarUsuarioViewModel usuario);
        //void Alterar(UsuarioViewModel entity);
    }
}
