using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AppCORE
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var a = 1;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    a = a + 1;
            //    await context.Response.WriteAsync($"USE a = {a}");

            //    await next();

            //    //await context.Response.WriteAsync($" Result = {a}");

            //});

            //MAP
            app.Map("/plus", (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    a = a + 2;
                    await context.Response.WriteAsync($" Map a = {a}");
                });
            });
            app.Map("/min", (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    a = a - 2;
                    await context.Response.WriteAsync($" Map a = {a}");
                });
            });

            app.Run(async (context) =>
            {
                a = a * 2;
                await context.Response.WriteAsync($", run a = {a}");
            });
        }
    }
}
