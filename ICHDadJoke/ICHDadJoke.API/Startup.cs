using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Mappings;
using ICHDadJoke.Core.Services;
using ICHDadJoke.Infrastructure.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ICHDadJoke.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ICanHazDadJoke API", Version = "v1" });
            });

            // AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SimpleMappings());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // DI
            services.AddHttpClient();
            services.AddScoped<IJokeDataClient, JokeDataClient>();
            services.AddTransient<IJokeService, JokeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ICanHazDadJoke API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
