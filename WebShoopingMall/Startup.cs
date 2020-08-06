using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebShoopingMall.Utility;

namespace WebShoopingMall
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
            SqlHelper.ConStr = Configuration["ConStr"].Trim();

            services.AddCors(m => m.AddPolicy("any", a =>a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            #region apiSettings
            services.AddSwaggerGen(m => m.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Shopping Mall", Version = "v1" }));
            services.AddControllers();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region apiSettings
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();
            app.UseCors();
            app.UseSwaggerUI(m => m.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Shopping Mall"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }
    }
}
