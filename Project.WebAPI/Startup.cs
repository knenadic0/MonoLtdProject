using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using Project.DAL;
using Project.DAL.Contexts;
using Project.Repository;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;

namespace Project.WebAPI
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
            services.AddMvc().AddControllersAsServices();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<GenericVehicleMakeService>().As<IVehicleMakeService>();
            containerBuilder.RegisterType<GenericVehicleModelService>().As<IVehicleModelService>();
            containerBuilder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
            containerBuilder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
            containerBuilder.RegisterType<VehicleContext>().As<IVehicleContext>();
            containerBuilder.RegisterType<Mapper>().As<IMapper>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=VehicleMake}/{action=Index}/{id?}");
            });

        }
    }
}
