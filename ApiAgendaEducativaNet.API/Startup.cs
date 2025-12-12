using ApiAgendaEducativaNet.Data.Context;
using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Services.Interfaces;
using ApiAgendaEducativaNet.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ApiAgendaEducativaNet.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendaEducativaNet.API
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

            // 🔗 Registrar DbContext con la cadena de conexión
            services.AddDbContext<AplicacionDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AgendaEducativaDB")));

            // 🔗 Registrar repositorios
            services.AddScoped<ITipoEmpresaRepository, TipoEmpresaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<ITurnoRepository, TurnoRepository>();
            services.AddScoped<INivelAcademicoRepository, NivelAcademicoRepository>();


            // 🔗 Registrar servicios
            services.AddScoped<ITipoEmpresaService, TipoEmpresaService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<ITurnoService, TurnoService>();
            services.AddScoped<INivelAcademicoService, NivelAcademicoService>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiAgendaEducativaNet.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAgendaEducativaNet.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
