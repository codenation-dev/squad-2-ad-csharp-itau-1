using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Log;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface ILogAplicacao
    {
        RetornoModificacaoLogViewModel Incluir(CadastroLogViewModel entity);

        RetornoModificacaoLogViewModel Alterar(AlteraLogViewModel entity);

        List<LogViewModel> ObterTodosLogs();

        LogViewModel ObterLogId(int id);

        Object TopLogApp(string filtro);

        Object TopLogAppId(int id_aplicacao);

        void Excluir(int id);
        
    }
}
