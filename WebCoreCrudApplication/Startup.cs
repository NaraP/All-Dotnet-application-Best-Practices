using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utillity.ErrorLogs;
using WebCoreCrudApplication.EmployeeRepository;
using WebCoreCrudApplication.Model;

namespace WebCoreCrudApplication
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

            // Registers the given DatabaseContext as a service which we can use for dependency injection
            services.Add(new ServiceDescriptor(typeof(IEmployeeRepositoryDAL), new EmployeeRepositoryDAL()));    // singleton
            services.Add(new ServiceDescriptor(typeof(IErrorLogger), new ErrorLogger()));    // singleton
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

                DefaultFilesOptions DefaultFile = new DefaultFilesOptions();
                DefaultFile.DefaultFileNames.Clear();
                DefaultFile.DefaultFileNames.Add("AllEmployees.html");
                app.UseDefaultFiles(DefaultFile);
                app.UseStaticFiles();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();

        }
    }
}
