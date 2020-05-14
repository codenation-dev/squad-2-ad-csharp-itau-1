using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Usuario;
using CentralErros.Application.ViewModel.Usuario.UsuarioAviso;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CentralErros.Application.App
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _repo;
        private readonly IMapper _mapper;
        private readonly Token _token;

        public UsuarioAplicacao(IUsuarioRepositorio repo, IMapper mapper, IOptions<Token> token)
        {
            _repo = repo;
            _mapper = mapper;
            _token = token.Value;
        }

        public UsuarioAppsViewModel_Usuario ObterUsuarioAplicacoes(string idUsuario)
        {
            var usuarioViewModel = new UsuarioAppsViewModel_Usuario()
            {
                IdUsuario = idUsuario,
                Aplicacoes = new List<AplicacaoViewModel_Usuario>()
            };
            var usuario = _repo.ObterUsuarioAplicacoes(idUsuario);
            if (usuario != null)
            {
                foreach(var usuarioAplicacao in usuario.UsuariosAplicacoes)
                {
                    usuarioViewModel.Aplicacoes.Add(new AplicacaoViewModel_Usuario()
                    {
                        IdAplicacao = usuarioAplicacao.Aplicacao.Id,
                        Nome = usuarioAplicacao.Aplicacao.Nome,
                        Descricao = usuarioAplicacao.Aplicacao.Descricao
                    });
                }
            }
            return usuarioViewModel;
        }

        public UsuarioAvisosViewModel_Usuario ObterUsuarioAvisos(string idUsuario)
        {
            var usuarioViewModel = new UsuarioAvisosViewModel_Usuario()
            {
                IdUsuario = idUsuario,
                Avisos = new List<AvisoViewModel_Usuario>()
            };
            var usuario = _repo.ObterUsuarioAvisos(idUsuario);
            if (usuario != null)
            {
                foreach (var usuarioAviso in usuario.UsuariosAvisos)
                {
                    if (!usuarioAviso.Visualizado)
                    {
                        usuarioViewModel.Avisos.Add(new AvisoViewModel_Usuario()
                        {
                            Id = usuarioAviso.Aviso.Id,
                            Descricao = usuarioAviso.Aviso.Descricao,
                            Data = usuarioAviso.Aviso.Data
                        });
                    }
                }
            }
            return usuarioViewModel;
        }

        public async Task<AvisoLoginViewModel> Registrar(RegistrarUsuarioViewModel regUsuario)
        {
            var usuario = await _repo.Registrar(regUsuario.Nome, regUsuario.Email, regUsuario.Senha, regUsuario.Role);
            var avisoLogin = new AvisoLoginViewModel()
            {
                Descricao = "Problemas ao registrar usuário",
                Token = null
            };
            if (usuario != null)
            {
                var token = GerarToken(usuario);
                avisoLogin.Descricao = "Usuário registrado com sucesso!";
                avisoLogin.Token = token;
            }
            return avisoLogin;
        }

        public async Task<AvisoLoginViewModel> Logar(LogarUsuarioViewModel logUsuario)
        {
            var usuario = await _repo.Logar(logUsuario.Email, logUsuario.Senha);
            var token = GerarToken(usuario);
            var avisoLogin = new AvisoLoginViewModel()
            {
                Descricao = "Email ou senha inválido!",
                Token = null
            };
            if (token != "")
            {
                avisoLogin.Descricao = "Usuário logado com sucesso!";
                avisoLogin.Token = token;
            }
            return avisoLogin;
        }

        public string GerarToken(Usuario usuario)
        {
            if (usuario == null) return "";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", usuario.Id),
                    new Claim(ClaimTypes.Name, usuario.UserName),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Issuer = _token.Emissor,
                Audience = _token.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_token.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }

        public UsuarioViewModel ObterUsuarioId(string idUsuario)
        {
            return _mapper.Map<UsuarioViewModel>(_repo.ObterUsuarioId(idUsuario));
        }

        public UsuarioViewModel Alterar(AlterarUsuarioViewModel usuario, string id)
        {
            return _mapper.Map<UsuarioViewModel>(_repo.Alterar(id, usuario.UserName, usuario.Email, usuario.Role).GetAwaiter().GetResult()); ;
        }

        public bool Deletar(string Id)
        {
            return _repo.Deletar(Id).GetAwaiter().GetResult();
        }
    }
}