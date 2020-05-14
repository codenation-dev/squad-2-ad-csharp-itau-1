using System.Collections.Generic;

namespace CentralErros.Application.ViewModel
{
    public class AplicacaoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<UsuarioAplicacaoViewModel> UsuariosAplicacoes { get; set; }
        public List<LogViewModel> Logs { get; set; }
    }
}
