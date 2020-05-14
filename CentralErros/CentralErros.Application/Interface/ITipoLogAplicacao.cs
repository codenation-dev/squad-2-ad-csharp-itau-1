using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.TipoLog;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface ITipoLogAplicacao
    {
        TipoLogViewModel Incluir(CadastroTipoLogViewModel entity);
        TipoLogViewModel Alterar(AlteraTipoLogViewModel entity);
        List<TipoLogViewModel> ObterTodosTipoLogs();
        TipoLogViewModel ObterTipoLogId(int id);
        List<OcorrenciaTipoLogViewModel> OcorrenciasTipoLog();
        void Excluir(int id);
    }
}
