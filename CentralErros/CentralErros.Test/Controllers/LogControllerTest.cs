using AutoMapper;
using CentralErros.Api.Controllers;
using CentralErros.Application.App;
using CentralErros.Application.Mapper;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Log;
using CentralErros.Data.Repositorio;
using CentralErros.Test.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CentralErros.Test.Controllers
{
    public class LogControllerTest
    {
        private readonly IMapper _mapper;
        private readonly FakeContext _ContextoFake;

        public LogControllerTest()
        {
            _ContextoFake = new FakeContext("LogControllerTest");
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void Incluir_Log_com_sucesso()
        {
            var context = _ContextoFake.GerarContexto("InlcuirLog_Sucesso");
            context = ContextFakeSeeds.SeedAplicacao(context);

            var repo = new LogRepositorio(context);
            var services = new LogAplicacao(repo, _mapper);
            var controller = new LogController(services);


            var result = controller.Post(GeraCadastroViewLog());

            Assert.IsType<ActionResult<RetornoModificacaoLogViewModel>>(result);
            var res = Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<RetornoModificacaoLogViewModel>(res.Value);
        }

        private CadastroLogViewModel GeraCadastroViewLog()
        {
            return new CadastroLogViewModel() 
                        { Descricao = "Erro no sistema do pdv",
                          IdAplicacao =  1,
                          IdTipoLog = 2
                        };
        }
    }
}
