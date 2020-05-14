using CentralErros.Domain.Modelo;
using System.Collections.Generic;

namespace CentralErros.Domain.Repositorio
{
    public interface ILogRepositorio : IRepositorioBase<Log>
    {
        List<Log> ObterTodosLogs();

        Log ObterLogId(int id);

        Dictionary<string, int> TopLogApp(int idAplicacao, out string nomeAplicacao, out string descricaoAplicacao);

        int ObterIdTopAppLog(string filtro);
    }
}
