using Gupy.Core.Interfaces.Common;
using Gupy.Core.Settings;
using ImageMagick;
using Microsoft.Extensions.Options;

namespace Gupy.Business.Common
{
    public class ImageProcessor : IImageProcessor
    {
        private readonly PhotoProcessorSettings _settings;

        public ImageProcessor(IOptions<PhotoProcessorSettings> options)
        {
            _settings = options.Value;
        }

        public byte[] ResizeImage(IFile photo)
        {
            using (var image = new MagickImage(photo.OpenReadStream()))
            {
                var size = new MagickGeometry(_settings.Width, _settings.Height)
                {
                    IgnoreAspectRatio = true
                };
                
                image.Resize(size);

                return image.ToByteArray();
            }
        }
    }
}