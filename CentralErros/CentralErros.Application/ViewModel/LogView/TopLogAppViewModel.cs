using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Application.ViewModel
{
    public class TopLogAppViewModel
    {
        public int IdAplicacao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int totalLogs { get; set; }
        public List<QtdeTipoLogViewModel> logs { get; set; }
    }
}
