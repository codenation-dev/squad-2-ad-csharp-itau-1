using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IAvisoAplicacao
    {
        void Incluir(AvisoViewModel entity);
        void Alterar(AvisoViewModel entity);
        void Excluir(int id);
        List<AvisoViewModel> ObterTodosAvisos(string idUsuario);
    }
}