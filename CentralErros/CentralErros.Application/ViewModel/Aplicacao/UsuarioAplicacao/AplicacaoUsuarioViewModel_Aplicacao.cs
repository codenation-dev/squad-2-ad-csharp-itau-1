using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Application.ViewModel.Aplicacao.UsuarioAplicacao
{
    public class AplicacaoUsuarioViewModel_Aplicacao
    {
        public int IdAplicacao { get; set; }
        public string Nome { get; set; }
        public List<UsuarioViewModel_Aplicacao> Usuarios { get; set; }
    }
}
