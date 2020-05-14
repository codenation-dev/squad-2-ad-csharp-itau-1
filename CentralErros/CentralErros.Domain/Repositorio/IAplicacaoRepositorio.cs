using CentralErros.Domain.Modelo;
using System.Collections.Generic;

namespace CentralErros.Domain.Repositorio
{
    public interface IAplicacaoRepositorio : IRepositorioBase<Aplicacao>
    {
        Aplicacao ObterAplicacaoUsuarios(int idAplicacao);
        Aplicacao ObterAplicacaoLogs(int idAplicacao);
        Aplicacao Incluir(Aplicacao aplicacao, string idUsuario);
        List<Aplicacao> ObterTodosAplicacoes();
        Aplicacao ObterAplicacaoId(int id);
        List<Aplicacao> ObterAplicacaoNome(string nome);
        Aplicacao ObterAplicacaoTipoLog(int app_id, int tipolog_id);
        bool VerificaAcessoUsuariosApp(string idUsuario, int idAplicacao);
    }
}