using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.UsuarioAplicacao;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAplicacaoAplicacao
    {
        UsuarioAplicacaoViewModel VinculaUsuarioAplicacao(ModificaViewModel_UsuarioAplicacao usuarioAplicacao,
            string idUsuario);
        bool ExcluirUsuarioAplicacao(ModificaViewModel_UsuarioAplicacao usuarioAplicacao, 
            string idUsuario);
    }
}
