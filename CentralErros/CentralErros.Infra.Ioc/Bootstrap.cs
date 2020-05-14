using CentralErros.Application.App;
using CentralErros.Application.Interface;
using CentralErros.Data;
using CentralErros.Data.Repositorio;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CentralErros.Infra.Ioc
{
    public static class Bootstrap
    {
        public static void RegistrarServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IAplicacaoRepositorio, AplicacaoRepositorio>();
            services.AddScoped<IAvisoRepositorio, AvisoRepositorio>();
            services.AddScoped<ILogRepositorio, LogRepositorio>();
            services.AddScoped<ITipoLogRepositorio, TipoLogRepositorio>();
            services.AddScoped<IUsuarioAplicacaoRepositorio, UsuarioAplicacaoRepositorio>();
            services.AddScoped<IUsuarioAvisoRepositorio, UsuarioAvisoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IAplicacaoAplicacao, AplicacaoAplicacao>();
            services.AddScoped<IAvisoAplicacao, AvisoAplicacao>();
            services.AddScoped<ILogAplicacao, LogAplicacao>();
            services.AddScoped<ITipoLogAplicacao, TipoLogAplicacao>();
            services.AddScoped<IUsuarioAplicacaoAplicacao, UsuarioAplicacaoAplicacao>();
            services.AddScoped<IUsuarioAvisoAplicacao, UsuarioAvisoAplicacao>();
            services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();

            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LuisDB")));
        }
    }
}
