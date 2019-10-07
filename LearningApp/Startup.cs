using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Shared.Models;
using Shared.Interface;
using Shared.Manager;

namespace LearningApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

             //.ConfigureApiBehaviorOptions(options =>
             // {
             //     //options.SuppressModelStateInvalidFilter = true;
             //     //options.SuppressInferBindingSourcesForParameters = true;
             //     //options.SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;
             //     options.InvalidModelStateResponseFactory = actionContext =>
             //     {
             //         var errors = actionContext.ModelState
             //             .Where(e => e.Value.Errors.Count > 0)
             //             .Select(e => new Error
             //             {
             //                 Name = e.Key,
             //                 Message = e.Value.Errors.First().ErrorMessage
             //             }).ToArray();

             //         return new BadRequestObjectResult(errors);
             //     };
             // });


            //services.AddMvc()
            //        .AddMvcOptions(options =>
            //        {
            //            options.Filters.Add<LoggingActionFilter>();
            //        });
            services.Configure<SecurityConfig>(Configuration.GetSection("SecurityConfig"));
            services.AddScoped<IFormatManager, FormatManager>();
            services.AddScoped<LoggingActionFilter>();
            services.AddSingleton<IAppEncryption, AppEncryption>();
            services.AddSingleton<IKeyManager, KeyManager>();
        }

        public class Error
        {
            public string Name { get; set; }

            public string Message { get; set; }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseMvc();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("MVC didn't find anything!");
            //});
        }
    }
}
