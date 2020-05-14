using CentralErros.Application.ViewModel.TipoLog;
using System.Collections.Generic;

namespace CentralErros.Application.ViewModel
{
    public class TipoLogViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<LogViewModel_TipoLog> Logs { get; set; }
    }
}
