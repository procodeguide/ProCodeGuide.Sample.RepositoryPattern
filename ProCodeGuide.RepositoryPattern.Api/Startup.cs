using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProCodeGuide.RepositoryPattern.Api.Adapters;
using ProCodeGuide.RepositoryPattern.Api.Services;
using ProCodeGuide.RepositoryPattern.DAL.DbContexts;
using ProCodeGuide.RepositoryPattern.DAL.Repositories;
using ProCodeGuide.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.RepositoryPattern.Api
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
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    ef => ef.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                    ServiceLifetime.Scoped);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProCodeGuide.RepositoryPattern.Api", Version = "v1" });
            });

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentAddressRepository, StudentAddressRepository>();
            services.AddTransient<IStudentSportRepository, StudentSportRepository>();

            services.AddTransient<IStudentAdapter, StudentAdapter>();

            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProCodeGuide.RepositoryPattern.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
