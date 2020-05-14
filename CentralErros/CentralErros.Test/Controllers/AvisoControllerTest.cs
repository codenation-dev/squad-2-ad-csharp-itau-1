using AutoMapper;
using CentralErros.Api.Controllers;
using CentralErros.Application.App;
using CentralErros.Application.Mapper;
using CentralErros.Application.ViewModel;
using CentralErros.Data.Repositorio;
using CentralErros.Test.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CentralErros.Test.Controllers
{
    public class AvisoControllerTest
    {
        private readonly IMapper _mapper;
        private readonly FakeContext _ContextoFake;

        public AvisoControllerTest()
        {
            _ContextoFake = new FakeContext("AplicacaoController");
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void Selecionar_Aviso_Com_Sucesso()
        {
            var context = _ContextoFake.GerarContexto("InlcuirAviso_Sucesso");
            context = ContextFakeSeeds.SeedAviso(context);
            var repo = new AvisoRepositorio(context);
            var services = new AvisoAplicacao(repo, _mapper);
            var controller = new AvisoController(services);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext
                .HttpContext
                .User = FakeUserClaims.GerarUsuarioPadraoParaContexto();

            var result = controller.Get();

            Assert.IsType<ActionResult<IEnumerable<AvisoViewModel>>>(result);
            var res = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<AvisoViewModel>>(res.Value);
        }
    }
}
