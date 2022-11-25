using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shopping.App.Services;
using Shopping.Domain.Repository;
using Shopping.Infrastructure.Context;
using Shopping.Infrastructure.Repositories;
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
            services.AddApiVersioning(options =>
                options.ReportApiVersions = true);
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping.API", Version = "v1" });
            });

            // To configure dependencies in Assembly use Scrutor  
            /* services.AddScoped<ICustomerRepository, CustomerRepository>();
             services.AddScoped<IProductRepository, ProductRepository>();
             services.AddScoped < IProductService, ProductService>();
             services.AddScoped<ICustomerService, CustomerService>();*/

            services.Scan(scan => scan
            .FromAssemblies(ShoppingDomain.Assembly,
            ShoppingApplication.Assembly,
            ShoppingInfrastructure.Assembly)
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
