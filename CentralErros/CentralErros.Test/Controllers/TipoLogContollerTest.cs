using AutoMapper;
using CentralErros.Api.Controllers;
using CentralErros.Application.App;
using CentralErros.Application.Mapper;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.TipoLog;
using CentralErros.Data.Repositorio;
using CentralErros.Test.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace CentralErros.Test.Controllers
{
    public class TipoLogContollerTest
    {
        private readonly IMapper _mapper;
        private readonly FakeContext _ContextoFake;

        public TipoLogContollerTest()
        {
            _ContextoFake = new FakeContext("LogControllerTest");
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void Incluir_TipoLog_com_sucesso()
        {
            var context = _ContextoFake.GerarContexto("InlcuirTipoLog_Sucesso");
            context = ContextFakeSeeds.SeedAplicacao(context);

            var repo = new TipoLogRepositorio(context);
            var services = new TipoLogAplicacao(repo, _mapper);
            var controller = new TipoLogController(services);

            var result = controller.Post(new CadastroTipoLogViewModel(){ Descricao = "Error" });

            Assert.IsType<ActionResult<TipoLogViewModel>>(result);
            var res = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<TipoLogViewModel>(res.Value);
        }

        [Fact]
        public void Selecionar_TipoLogId()
        {
            var context = _ContextoFake.GerarContexto("InlcuirTipoLog_Sucesso");
            context = ContextFakeSeeds.SeedAplicacao(context);

            var repo = new TipoLogRepositorio(context);
            var services = new TipoLogAplicacao(repo, _mapper);
            var controller = new TipoLogController(services);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext
                .HttpContext
                .User = FakeUserClaims.GerarUsuarioPadraoParaContexto();

            var result = controller.Get(1);

            Assert.IsType<ActionResult<TipoLogViewModel>>(result);
            var res = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<TipoLogViewModel>(res.Value);
        }

        [Fact]
        public void Selecionar_TipoLogTodos()
        {
            var context = _ContextoFake.GerarContexto("InlcuirTipoLog_Sucesso");
            context = ContextFakeSeeds.SeedAplicacao(context);

            var repo = new TipoLogRepositorio(context);
            var services = new TipoLogAplicacao(repo, _mapper);
            var controller = new TipoLogController(services);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext
                .HttpContext
                .User = FakeUserClaims.GerarUsuarioPadraoParaContexto();

            var result = controller.Get();

            Assert.IsType<ActionResult<IEnumerable<TipoLogViewModel>>>(result);
            var res = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<TipoLogViewModel>>(res.Value);
        }

        [Fact]
        public void Selecionar_TipoLog_Ocorrencia()
        {
            var context = _ContextoFake.GerarContexto("InlcuirTipoLog_Sucesso");
            context = ContextFakeSeeds.SeedAplicacao(context);

            var repo = new TipoLogRepositorio(context);
            var services = new TipoLogAplicacao(repo, _mapper);
            var controller = new TipoLogController(services);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext
                .HttpContext
                .User = FakeUserClaims.GerarUsuarioPadraoParaContexto();

            var result = controller.GetOcorrenciasTipoLog();

            Assert.IsType<ActionResult<List<OcorrenciaTipoLogViewModel>>>(result);
            var res = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<List<OcorrenciaTipoLogViewModel>>(res.Value);
        }
    }
}
