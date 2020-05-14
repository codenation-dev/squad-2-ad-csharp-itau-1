using CentralErros.Domain.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralErros.Domain.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario ObterUsuarioAplicacoes(string idUsuario);
        Usuario ObterUsuarioAvisos(string idUsuario);
        Usuario ObterUsuarioId(string idUsuario);
        Task<Usuario> Alterar(string Id, string nome, string email, string role);
        Task<bool> Deletar(string Id);
        Task<Usuario> Registrar(string nome, string email, string senha, string role);
        Task<Usuario> Logar(string email, string senha);
    }
}