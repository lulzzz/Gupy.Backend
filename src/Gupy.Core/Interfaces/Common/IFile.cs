using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Gupy.Core.Interfaces.Common
{
    public interface IFile
    {
        long Length { get; }
        string FileName { get; }
        byte[] FileContents { get; }
        Stream OpenReadStream();
        void CopyTo(Stream target);
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
    }
}