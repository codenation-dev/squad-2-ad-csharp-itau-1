using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Application.ViewModel.Usuario
{
    public class UsuarioAppsViewModel_Usuario
    {
        public string IdUsuario { get; set; }
        public List<AplicacaoViewModel_Usuario> Aplicacoes { get; set; }
    }
}