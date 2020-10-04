﻿using Microsoft.Extensions.DependencyInjection;

 namespace Gupy.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void BuildCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .AllowAnyHeader();
                });
            });
        }
    }
}