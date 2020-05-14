using AutoMapper;
using CentralErros.Application.App;
using CentralErros.Application.Mapper;
using CentralErros.Data.Repositorio;
using CentralErros.Domain.Modelo;
using CentralErros.Test.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CentralErros.Test.Controllers
{
    public class AuthControllerTest
    {
        //private readonly IMapper _mapper;
        //private readonly FakeContext _fakeContext;
        //private readonly UserManager<Usuario> _userManager;

        //public AuthControllerTest()
        //{
        //    _fakeContext = new FakeContext("AuthoController");
        //    var configuration = new MapperConfiguration(cfg => {
        //        cfg.AddProfile(new AutoMapperConfig());
        //    });

        //    _mapper = configuration.CreateMapper();
        //    _userManager = new UserManager<Usuario>();
        //}

        //[Fact]
        //public void Registrar_Usuario_com_Sucesso()
        //{
        //    var context = _fakeContext.GerarContexto("RegistrarUsuario_sucesso");

        //    var repo = new UsuarioRepositorio(context);
        //    var services = new UsuarioAplicacao(repo, _mapper);
        //}



    }
}
