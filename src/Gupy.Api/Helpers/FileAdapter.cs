using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Common;
using Microsoft.AspNetCore.Http;

namespace Gupy.Api.Helpers
{
    public class FileAdapter : IFile
    {
        private readonly IFormFile _file;
        public long Length => _file.Length;
        public string FileName => _file.FileName;

        public FileAdapter(IFormFile file)
        {
            _file = file;
        }

        public Stream OpenReadStream()
        {
            return _file.OpenReadStream();
        }

        public void CopyTo(Stream target)
        {
            _file.CopyTo(target);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return _file.CopyToAsync(target, cancellationToken);
        }
    }
}