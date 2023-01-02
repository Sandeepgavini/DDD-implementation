using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shopping.Infrastructure.Context;
using System.Reflection;
using System;
using Shopping.App;
using Shopping.Domain;
using Shopping.Infrastructure;

namespace Shopping.API
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

            // Injecting the EF Core into the services
            services.AddEntityFrameworkSqlServer()
              .AddDbContext<ShoppingContext>(options =>
              {
                  options.UseSqlServer(Configuration.GetConnectionString("Shopping"),
                      sqlServerOptionsAction: sqlOptions =>
                      {
                          sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                          sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30)
                              , errorNumbersToAdd: null);
                      });
              },

                  ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
              );
            services.AddScoped<DbContext>(x => x.GetRequiredService<ShoppingContext>());

            // Versioning the API for major changes and bug fixes
            services.AddApiVersioning(options =>
                options.ReportApiVersions = true);
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddControllers().AddNewtonsoftJson(options=>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping.API", Version = "v1" });
            });

          // Using Scrutor to configure services from the Assembly
            services.Scan(scan => scan
            .FromAssemblies(ShoppingDomain.Assembly,
            ShoppingApplication.Assembly,
            ShoppingInfrastructure.Assembly)
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

            // Activating CORs for the API
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigin", options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
