using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs
{
    public class LogsViewModel_Aplicacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoLog { get; set; }
        public TipoLogViewModel_Aplicacao TipoLog { get; set; }
    }
}
