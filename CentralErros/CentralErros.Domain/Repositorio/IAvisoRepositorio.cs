using CentralErros.Domain.Modelo;
using System.Collections.Generic;

namespace CentralErros.Domain.Repositorio
{
    public interface IAvisoRepositorio : IRepositorioBase<Aviso>
    {
        List<Aviso> ObterTodosAvisos(string idUsuario);
    }
}