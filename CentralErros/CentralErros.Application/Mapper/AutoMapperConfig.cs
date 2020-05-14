using AutoMapper;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Aplicacao;
using CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs;
using CentralErros.Application.ViewModel.Log;
using CentralErros.Application.ViewModel.TipoLog;
using CentralErros.Application.ViewModel.UsuarioAplicacao;
using CentralErros.Domain.DTO;
using CentralErros.Domain.Modelo;
using System;

namespace CentralErros.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            CreateMap<Aplicacao, AplicacaoViewModel>().ReverseMap();
            CreateMap<Aplicacao, CadastroAplicacaoViewModel>().ReverseMap();
            CreateMap<Aplicacao, AplicacaoSimplesViewModel>().ReverseMap();
            CreateMap<Aplicacao, AplicacaoViewModel_Log>().ReverseMap();
            CreateMap<Aplicacao, AplicacaoViewModel_UsuarioAplicacao>().ReverseMap();
            CreateMap<Aplicacao, AplicacaoLogsViewModel_Aplicacao>().ReverseMap();
            CreateMap<Aviso, AvisoViewModel>().ReverseMap();
            CreateMap<Log, RetornoModificacaoLogViewModel>().ReverseMap();
            CreateMap<Log, AlteraLogViewModel>().ReverseMap();
            CreateMap<Log, LogViewModel>().ReverseMap();
            CreateMap<Log, CadastroLogViewModel>().ReverseMap();
            CreateMap<Log, LogsViewModel_Aplicacao>().ReverseMap();
            CreateMap<Log, LogViewModel_TipoLog>().ReverseMap();
            CreateMap<TipoLog, TipoLogViewModel_Log>().ReverseMap();
            CreateMap<TipoLog, TipoLogViewModel>().ReverseMap();
            CreateMap<TipoLog, CadastroTipoLogViewModel>().ReverseMap();
            CreateMap<TipoLog, AlteraTipoLogViewModel>().ReverseMap();
            CreateMap<TipoLog, TipoLogViewModel_Aplicacao>().ReverseMap();
            CreateMap<UsuarioAplicacao, UsuarioAplicacaoViewModel>().ReverseMap();
            CreateMap<UsuarioAviso, UsuarioAvisoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel_UsuarioAplicacao>().ReverseMap();
            CreateMap<OcorrenciaTipoLogDTO, OcorrenciaTipoLogViewModel>().ReverseMap();
        }
    }
}