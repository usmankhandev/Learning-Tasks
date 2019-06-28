using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;


using restApi.Models;
namespace restApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration) => Configuration = configuration;
        // public Startup(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestContext>
                (options => options.UseSqlServer(Configuration["Data:RestApiConnection:ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {

                            builder.WithOrigins("https://localhost:44345/");
                        });
                    options.AddPolicy("AnotherPolicy",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44345/Home/About")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                        });
                    options.AddPolicy("AllowSubdomain",
                        builder =>
                        {
                            builder.SetIsOriginAllowedToAllowWildcardSubdomains();
                        });
                    options.AddPolicy("AllowHeaders",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44345/")
                                .WithHeaders(HeaderNames.ContentType, "x-custom-header");
                        });
                    options.AddPolicy("AllowAllHeaders",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44345/")
                                .AllowAnyHeader();
                        });
                    options.AddPolicy("ExposeResponseHeaders",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44345/")
                                .WithExposedHeaders("x-custom-header");
                        });
                    options.AddPolicy("AllowCredentials",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44345/")
                                .AllowCredentials();
                        });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(policy => policy.WithHeaders(HeaderNames.CacheControl));
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();

        }

    }
}