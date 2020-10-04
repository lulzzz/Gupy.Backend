using Gupy.Business.Common;
using Gupy.Core.Interfaces.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Gupy.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IImageProcessor, ImageProcessor>();
            services.AddScoped<IPhotoStorage, CloudPhotoStorage>();
        }
    }
}