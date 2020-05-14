using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Application.ViewModel.Log
{
    public class RetornoModificacaoLogViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoLog { get; set; }
        public int IdAplicacao { get; set; }
    }
}
