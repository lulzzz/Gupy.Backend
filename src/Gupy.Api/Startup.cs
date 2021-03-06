using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;
using AutoMapper;
using FluentValidation.AspNetCore;
using Gupy.Api.Extensions;
using Gupy.Business.Extensions;
using Gupy.Business.Queries.Products;
using Gupy.Core.MapperProfiles;
using Gupy.Core.Settings;
using Gupy.Data.Extensions;
using HybridModelBinding;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Gupy.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (Environment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration);

            services.BuildCors();

            services.AddControllers()
                .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
                .AddFluentValidation(fv =>
                {
                    fv.ImplicitlyValidateChildProperties = true;
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.RegisterValidatorsFromAssembly(typeof(Startup).Assembly);
                })
                .AddHybridModelBinder(o =>
                    o.FallbackBindingOrder = new[] {Source.Route, Source.QueryString, Source.Body, Source.Form});
            ;

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = Configuration["Auth0:Domain"];
                o.Audience = Configuration["Auth0:Audience"];
            });

            services.AddAutoMapper(typeof(Startup).Assembly, typeof(ProductProfile).Assembly);
            services.AddMediatR(typeof(Startup).Assembly, typeof(GetProductsQueryHandler).Assembly);

            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));
            services.Configure<AzureSettings>(Configuration.GetSection("AzureSettings"));
            services.Configure<PhotoProcessorSettings>(Configuration.GetSection("PhotoProcessorSettings"));

            services.AddRepositories();
            services.AddBusinessServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureLoggingMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Environment.WebRootPath, "files")),
                RequestPath = "/files"
            });

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture)
            });

            app.UseStatusCodePages();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/ping", async context => await context.Response.WriteAsync("Pong!"));
                endpoints.MapControllers();
            });
        }
    }
}