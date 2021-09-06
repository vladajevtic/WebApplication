using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEDCWebAPI.Models.Repository.Implementations;
using SEDCWebApplication12.Models.Repository.Implementations;
using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Implementations;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.DAL.Data.Implementations;
using WebApplication.DAL.Data.Interfaces;
using SEDCWebAPI.Models.Repository.Implementations;
using DataBaseCustomerRepository = SEDCWebAPI.Models.Repository.Implementations.DataBaseCustomerRepository;

namespace WebAPI
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
            services.AddControllers();
            services.AddAutoMapper(typeof(ProductManager));
            services.AddAutoMapper(typeof(EmployeeManager));
            
            services.AddAutoMapper(typeof(CustomerManager));
            services.AddScoped<IEmployeeRepository, DataBaseEmployeeRepository>();
            services.AddScoped<IProductRepository, DataBaseProductRepository>();
            services.AddScoped<ICustomerRepository, DataBaseCustomerRepository>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            services.AddScoped<ICustomerDAL, CustomerDAL>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IProductDAL, ProductDAL>();
            services.AddScoped<IProductManager, ProductManager>();
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
    }
}
