using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralErros.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly Contexto _contexto;

        public UsuarioRepositorio(UserManager<Usuario> userManager, Contexto contexto)
        {
            _userManager = userManager;
            _contexto = contexto;
        }

        public async Task<Usuario> Registrar(string nome, string email, string senha, string role)
        {
            var usu = new Usuario()
            {
                UserName = nome,
                Email = email,
                Role = role,
                EmailConfirmed = true
            };

            var retorno = await _userManager.CreateAsync(usu, senha);

            if (!retorno.Succeeded)
                return null;

            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Usuario> Logar(string email, string senha)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario != null &&
                await _userManager.CheckPasswordAsync(usuario, senha))
            {
                return usuario;
            }
            return null;
        }

        public Usuario ObterUsuarioAplicacoes(string idUsuario)
        {
            IQueryable<Usuario> usuarios = _contexto.Users
                .Where(x => x.Id == idUsuario)
                .Include(x => x.UsuariosAplicacoes);

            usuarios = usuarios.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Aplicacao);

            return usuarios.AsNoTracking().FirstOrDefault();
        }

        public Usuario ObterUsuarioAvisos(string idUsuario)
        {
            IQueryable<Usuario> usuarios = _contexto.Users
                .Where(x => x.Id == idUsuario)
                .Include(x => x.UsuariosAvisos);

            usuarios = usuarios.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Aviso);

            return usuarios.AsNoTracking().FirstOrDefault();
        }

        public Usuario ObterUsuarioId(string idUsuario)
        {
            return _userManager.FindByIdAsync(idUsuario).GetAwaiter().GetResult();
        }

        public async Task<Usuario> Alterar(string Id, string nome, string email, string role)
        {
            var usuario = await _userManager.FindByIdAsync(Id);
            usuario.UserName = nome;
            usuario.Email = email;
            usuario.Role = role;

            var retorno = await _userManager.UpdateAsync(usuario);

            if (!retorno.Succeeded)
                return null;

            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> Deletar(string Id)
        {
            var usuario = await _userManager.FindByIdAsync(Id);

            var retorno = await _userManager.DeleteAsync(usuario);

            if (!retorno.Succeeded)
                return false;
            return true;
        }
    }
}