using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SampleECommerce.Core.Caching;
using SampleECommerce.Service.Product;
using SampleECommerce.Service.ShoppingCart;
using Swashbuckle.AspNetCore.Swagger;

namespace SampleECommerce.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "SampleECommerce";
                options.Configuration = "localhost:6379"; //Your Redis connection port
            });

            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICacheManager, CacheManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "Swagger on ASP.NET Core",
                    Version = "1.0.0",
                    Description = "Try Swagger on (ASP.NET Core 2.1)",
                    Contact = new Contact()
                    {
                        Name = "Celil Ercan",
                        Url = "http://localhost:24506",
                        Email = "celilercan91@gmail.com"
                    },
                    TermsOfService = "http://swagger.io/terms/"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseSwagger()
               .UseSwaggerUI(c => {

                   c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test .Net Core");
               });
            app.UseMvc();
        }
    }
}
