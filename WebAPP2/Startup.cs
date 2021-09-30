using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using SEDCWebApplication12.Models.Repository.Implementations;
//using SEDCWebApplication12.Models.Repository.Interfaces;
using System.Linq;
using WebApplication.BLL.Logic.Implementations;
using WebApplication.BLL.Logic.Interfaces;
//using WebApplication.DAL.Data.Implementations;
//using WebApplication.DAL.Data.Interfaces;
//using WebApplicationEntityFramework.Interfaces;
//using WebApplicationEntityFramework.Implementation;
using WebApplication.CodeFirst.Implementations;
using WebApplication.CodeFirst.Interfaces;
using WebAPP2.Models.Repository.Implementations;
using WebApplication.CodeFirst;
using Microsoft.EntityFrameworkCore;
using WebAPP2.Models.Repository.Interfaces;
using WebAPP2.Services.Interfaces;
using WebAPP2.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            services.AddControllers(options =>
            {
                var jsonInputFormatter = options.InputFormatters
                    .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
                    .Last();
                jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report");
                jsonInputFormatter.SupportedMediaTypes.Add("application/json");
            }
        );
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SEDC2")));
           
            services.AddAutoMapper(typeof(ProductManager));
            services.AddAutoMapper(typeof(EmployeeManager));
            services.AddAutoMapper(typeof(CustomerManager));
            services.AddAutoMapper(typeof(OrderManager));
            
            //wepAPI
            services.AddScoped<IEmployeeRepository, DataBaseEmployeeRepository>();
            services.AddScoped<IProductRepository, DataBaseProductRepository>();
            services.AddScoped<ICustomerRepository, DataBaseCustomerRepository>();
            services.AddScoped<IOrderRepository, DataBaseOrderRepository>();
            services.AddScoped<IUserService, UserService>();
            //BLL
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IUserManager, UserManager>();
            //DAL
            services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            services.AddScoped<ICustomerDAL, CustomerRepository>();
            services.AddScoped<IProductDAL, ProductRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IUserDAL, UserRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {

                    builder.AllowAnyOrigin();
                     builder.AllowAnyMethod();
                     builder.AllowAnyHeader();
                });
                
        });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseRouting();
           
            app.UseCors();
            
            

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
   

        }
    }
}
