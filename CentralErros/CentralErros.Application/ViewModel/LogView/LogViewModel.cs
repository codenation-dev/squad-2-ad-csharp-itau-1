using CentralErros.Application.ViewModel.Log;
using System;

namespace CentralErros.Application.ViewModel
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public TipoLogViewModel_Log TipoLog { get; set; }
        public AplicacaoViewModel_Log Aplicacao { get; set; }
    }
}