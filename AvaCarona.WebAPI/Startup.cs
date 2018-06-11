using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AvaCarona.API.Repositories;
using AvaCarona.API.Domain;
using AvaCarona.API.Business;
using AvaCarona.WebAPI.ModelView;

namespace AvaCarona.WebAPI
{
    public class Startup
    {
        private static IConfigurationRoot Configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CaronaDB;Trusted_Connection=True;";
            var connectionString = Startup.Configuration["DefaultConnection"];
            services.AddDbContext<API.Repositories.CaronaAppContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ICaronaRepository, CaronaRepositoryEF>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepositoryEF>();

            services.AddScoped<IFachada, FachadaImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
                cfg.CreateMap<ColaboradorUpdateDto, Colaborador>()
                    .ForMember(d => d.Id, opt => opt.Ignore())
                    .ForMember(d => d.CreateDate, opt => opt.Ignore())
            );

            app.UseMvc();
        }
    }
}
