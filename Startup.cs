using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripItemsForEleks.Models;

namespace TripItemsForEleks
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDBContext>(options =>
                        options.UseSqlServer(_config.GetConnectionString("TripItemsDBConnections"))
                        .UseLazyLoadingProxies());
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<ITripRepository, SQLTripRepository>();
            services.AddTransient<IItemRepository, SQLItemRepository>();
            services.AddTransient<IHomeRepository, SQLHomeRepository>();
            services.AddMvc();
            services.AddControllers();
          
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
               endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}")
           );
        }
    }
}

