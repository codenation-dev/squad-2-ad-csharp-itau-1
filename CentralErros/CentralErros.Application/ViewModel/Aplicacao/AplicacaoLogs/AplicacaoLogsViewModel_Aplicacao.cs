using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs
{
    public class AplicacaoLogsViewModel_Aplicacao
    {
        public int IdAplicacao { get; set; }
        public string Nome { get; set; }
        public List<LogsViewModel_Aplicacao> Logs { get; set; }
    }
}