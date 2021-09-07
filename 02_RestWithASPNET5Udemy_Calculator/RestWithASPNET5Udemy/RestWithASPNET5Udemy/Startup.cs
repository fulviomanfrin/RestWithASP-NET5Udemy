using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET5Udemy.Business;
using RestWithASPNET5Udemy.Business.Implementations;
using RestWithASPNET5Udemy.Model.Context;
using Microsoft.EntityFrameworkCore;
using RestWithASPNET5Udemy.Repositories;
using RestWithASPNET5Udemy.Repositories.Implementations;
using Serilog;
using Pomelo.EntityFrameworkCore.MySql;


namespace RestWithASPNET5Udemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddControllers();

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
            
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
            
            //Versioning
            services.AddMvc();

            services.AddApiVersioning(
            config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;

            });


            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            services.AddScoped<IBookRepository, BookRepositoryImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database Migration Failed", ex);
                throw;
            };
        }
    }
}
