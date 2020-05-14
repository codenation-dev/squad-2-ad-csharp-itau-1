namespace CentralErros.Application.ViewModel
{
    public class UsuarioAvisoViewModel
    {
        public int Id { get; set; }
        public bool Visualizado { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public AvisoViewModel Aviso { get; set; }
    }
}
