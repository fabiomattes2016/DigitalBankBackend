using DB.Data.Context;
using DB.Data.Repositories;
using DB.Manager.Implementations;
using DB.Manager.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.WebApi
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
            services.AddControllers();

            // DbContext
            services.AddDbContext<DigitalBankContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();

            // Implementations
            services.AddScoped<IClienteManager, ClienteManager>();

            // Swagger
            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo { Title = "Digital Bank API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(swui => 
            {
                swui.RoutePrefix = string.Empty;
                swui.SwaggerEndpoint("./swagger/v1/swagger.json", "DB V1");
            });

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
