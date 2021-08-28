using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VY.Soccer.Player.Info.Api.Extensions;
using VY.Soccer.Player.Info.Api.Validation;
using VY.Soccer.Player.Info.Models.Player;
using VY.Soccer.Player.Info.Service.Concreate;
using VY.Soccer.Player.Info.Service.Player;

namespace VY.Soccer.Player.Info.Api
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

            services.AddControllers()
                .AddFluentValidation(i=>i.RunDefaultMvcValidationAfterFluentValidationExecutes=false);
            
            services.AddHealthChecks();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VY.Soccer.Player.Info.Api", Version = "v1" });
            });
            services.ConfigureMapping();
            services.AddTransient<IValidator<PlayerDTO>,PlayerValidator>();
            services.AddScoped<IPlayerService, PlayerManager>();
            services.AddHttpClient("bankaapi", config => {
                config.BaseAddress = new Uri("http://bankaapi.com");
                config.DefaultRequestHeaders.Add("Authorization", "Bearer dasgsjdfgnlfsdkjn");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VY.Soccer.Player.Info.Api v1"));
            }

            app.UseCustomHealthCheck();

            app.UseRouting();

            app.UseAuthorization();

            app.UseResponseCaching();

            a

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
