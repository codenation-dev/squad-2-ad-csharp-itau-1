using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Aplicacao;
using CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs;
using CentralErros.Application.ViewModel.Aplicacao.UsuarioAplicacao;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IAplicacaoAplicacao
    {
        AplicacaoSimplesViewModel Incluir(CadastroAplicacaoViewModel entity, string idUsuario);
        void Alterar(AplicacaoSimplesViewModel entity);
        void Excluir(int id);
        AplicacaoUsuarioViewModel_Aplicacao ObterAplicacaoUsuarios(int idAplicacao);
        AplicacaoLogsViewModel_Aplicacao ObterAplicacaoLogs(int idAplicacao);
        List<AplicacaoSimplesViewModel> ObterTodosAplicacoes();
        AplicacaoSimplesViewModel ObterAplicacaoId(int id);
        List<AplicacaoSimplesViewModel> ObterAplicacaoNome(string nome);
        AplicacaoLogsViewModel_Aplicacao ObterAplicacaoTipoLog(int app_id, int tipolog_id);
        bool VerificaAcessoUsuariosApp(string idUsuario, int idAplicacao);
    }
}
