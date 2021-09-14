using Microsoft.AspNetCore.Builder;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEDCWebApplication12.Models.Repository.Implementations;
using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Implementations;
using WebApplication.BLL.Logic.Interfaces;
//using WebApplication.DAL.Data.Implementations;
//using WebApplication.DAL.Data.Interfaces;
using WebApplicationEntityFramework.Implementation;
using WebApplicationEntityFramework.Interfaces;
using SEDCWebAPI.Models.Repository.Implementations;
using WebApplication.CodeFirst;
using Microsoft.EntityFrameworkCore;

namespace WebAPP2
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
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SEDC2")));

            services.AddAutoMapper(typeof(ProductManager));
            services.AddAutoMapper(typeof(EmployeeManager));
            services.AddAutoMapper(typeof(CustomerManager));
            services.AddScoped<IEmployeeRepository, DataBaseEmployeeRepository>();
            services.AddScoped<IProductRepository, DataBaseProductRepository>();
            services.AddScoped<ICustomerRepository, SEDCWebAPI.Models.Repository.Implementations.DataBaseCustomerRepository>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            services.AddScoped<ICustomerDAL, CustomerRepository>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IProductDAL, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderDAL, OrderRepository>();

          

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
