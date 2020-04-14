using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestauranteCodenation.Application.App;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.Mapper;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<ITipoPratoRepositorio, TipoPratoRepositorio>();
            services.AddScoped<IAgendaCardapioRepositorio, AgendaCardapioRepositorio>();
            services.AddScoped<IAgendaRepositorio, AgendaRepositorio>();
            services.AddScoped<ICardapioRepositorio, CardapioRepositorio>();
            services.AddScoped<IIngredienteRepositorio, IngredienteRepositorio>();
            services.AddScoped<IPratoRepositorio, PratoRepositorio>();
            services.AddScoped<IPratosIngredientesRepositorio, PratosIngredientesRepositorio>();

            services.AddScoped<ITipoPratoAplicacao, TipoPratoAplicacao>();
            services.AddScoped<IAgendaCardapioAplicacao, AgendaCardapioAplicacao>();
            services.AddScoped<IAgendaAplicacao, AgendaAplicacao>();
            services.AddScoped<ICardapioAplicacao, CardapioAplicacao>();
            services.AddScoped<IIngredienteAplicacao, IngredienteAplicacao>();
            services.AddScoped<IPratoAplicacao, PratoAplicacao>();
            services.AddScoped<IPratosIngredientesAplicacao, PratosIngredientesAplicacao>();

            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddSwaggerGen(x => x.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Restaurante Codenation", Version = "v1" }));
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Restaurante");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
