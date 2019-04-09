using System;
using System.IO;
using System.Reflection;
using Livraria.Infra.CrossCutting.IOC;
using Livraria.Infra.Data.Context;
using Livraria.WebApi.Configuratios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Livraria.WebApi
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
            services.AddMvc()
                 .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddJsonOptions(option =>
                 {
                     var resolver = option.SerializerSettings.ContractResolver;
                     if (resolver != null)
                         (resolver as DefaultContractResolver).NamingStrategy = null;
                 });

            services.AddAutoMapperSetup();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Livraria WebApi",
                    Description = "Sistema de controle de uma livraria",
                    Contact = new Contact { Name = "Guilherme Vilatoro Santos", Email = "vilatorog@gmail.com" }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            InjectionDependencies.RegisterDependencies(services);

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(options => options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Livraria WebApi");
                c.RoutePrefix = string.Empty;
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<LivrariaContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}