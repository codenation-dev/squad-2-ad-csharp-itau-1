using AutoMapper;
using CentralErros.Application.App;
using CentralErros.Application.Interface;
using CentralErros.Application.Mapper;
using CentralErros.Application.ViewModel;
using CentralErros.Data;
using CentralErros.Data.Repositorio;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using CentralErros.Infra.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CentralErros.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrap.RegistrarServices(services, Configuration);
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            /*services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
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
            services.AddScoped<IUsuarioAplicacao, Application.App.UsuarioAplicacao>();*/

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Central Erros", Version = "v1" });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
            });

            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MinhaConexao")));

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<Contexto>();

            var section = Configuration.GetSection("Token");
            services.Configure<Token>(section);

            var token = section.Get<Token>();
            var key = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = token.ValidoEm,
                    ValidIssuer = token.Emissor
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configurando o Swagger
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Central Erros");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
