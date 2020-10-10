using System;
using System.IO;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Gupy.Business.Common
{
    public class FileSystemPhotoStorage : IPhotoStorage
    {
        private readonly IImageProcessor _imageProcessor;
        private readonly IHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public FileSystemPhotoStorage(IImageProcessor imageProcessor, IHostEnvironment environment,
            IConfiguration configuration)
        {
            _imageProcessor = imageProcessor;
            _environment = environment;
            _configuration = configuration;
        }

        public async Task<string> StorePhotoAsync(IFile photo)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "files", fileName);

            var resizedPhoto = _imageProcessor.ResizeImage(photo);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(resizedPhoto);
            }

            return $"{_configuration.GetSection("HostName")}/files/{fileName}";
        }

        public Task<bool> DeletePhotoAsync(string fileName)
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "files", fileName);
            if (!File.Exists(filePath))
            {
                return Task.FromResult(false);
            }

            File.Delete(filePath);
            return Task.FromResult(true);
        }
    }
}