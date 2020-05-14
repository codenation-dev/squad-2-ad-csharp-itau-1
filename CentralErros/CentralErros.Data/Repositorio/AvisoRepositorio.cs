using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CentralErros.Data.Repositorio
{
    public class AvisoRepositorio : RepositorioBase<Aviso>, IAvisoRepositorio
    {
        public AvisoRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public List<Aviso> ObterTodosAvisos(string idUsuario)
        {
            var avisos = (from aviso in _contexto.Aviso
                          join usuaviso in _contexto.UsuariosAvisos
                          on aviso.Id equals usuaviso.IdAviso
                          where usuaviso.Visualizado == false && usuaviso.IdUsuario == idUsuario
                          select aviso).ToList();
            return avisos;
        }
    }
}
