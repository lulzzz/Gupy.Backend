using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Gupy.Core.Interfaces.Common;
using Gupy.Core.Settings;
using Microsoft.Extensions.Options;

namespace Gupy.Business.Common
{
    public class CloudPhotoStorage : IPhotoStorage
    {
        private readonly AzureSettings _settings;
        private readonly IImageProcessor _imageProcessor;

        public CloudPhotoStorage(IOptions<AzureSettings> options, IImageProcessor imageProcessor)
        {
            _settings = options.Value;
            _imageProcessor = imageProcessor;
        }

        public async Task<string> StorePhotoAsync(IFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var client = new BlobClient(_settings.ConnectionString, _settings.ContainerName, fileName);

            var resizedPhoto = _imageProcessor.ResizeImage(file);
            await using (var stream = new MemoryStream(resizedPhoto))
            {
                await client.UploadAsync(stream);
            }

            return $"{_settings.StorageUrl}/{_settings.ContainerName}/{fileName}";
        }

        public async Task<bool> DeletePhotoAsync(string fileName)
        {
            var client = new BlobClient(_settings.ConnectionString, _settings.ContainerName, fileName);
            var result = await client.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            return result.Value;
        }
    }
}