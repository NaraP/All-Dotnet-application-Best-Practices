using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcCoreCRUDApplication.EmployeeRepository;
using Utillity.ErrorLogs;

namespace MvcCoreCRUDApplication
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
            services.AddMvc();

            services.Add(new ServiceDescriptor(typeof(IEmployeeRepositoryDAL), new EmployeeRepositoryDAL()));    // singleton

            services.Add(new ServiceDescriptor(typeof(IErrorLogger), new ErrorLogger()));    // singleton

            //services.AddSingleton(new ServiceDescriptor(typeof(IEmployeeRepositoryDAL), new EmployeeRepositoryDAL()));

            services.Configure<GetConfigFileData>(Configuration.GetSection("GetConfigFileData"));

            services.Add(new ServiceDescriptor(typeof(IEmployeeRepositoryDAL), typeof(EmployeeRepositoryDAL), ServiceLifetime.Singleton)); // Transient

            services.Add(new ServiceDescriptor(typeof(IErrorLogger), typeof(ErrorLogger), ServiceLifetime.Singleton)); // Transient

            //services.Add(new ServiceDescriptor(typeof(ILog), typeof(MyConsoleLogger), ServiceLifetime.Scoped));    // Scoped

            //Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime.
            // Transient: The IoC container will create a new instance of the specified service type every time you ask for it.
            // Scoped: IoC container will create an instance of the specified service type once per request and will be shared in a single request.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
