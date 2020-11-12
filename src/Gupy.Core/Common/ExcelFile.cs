using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Common;

namespace Gupy.Core.Common
{
    public class ExcelFile : IFile
    {
        private readonly string _fileName;
        public long Length => FileContents.Length;
        public string FileName => _fileName;
        public byte[] FileContents { get; }

        public ExcelFile(string fileName, byte[] excelData)
        {
            _fileName = fileName;
            FileContents = excelData;
        }

        public Stream OpenReadStream()
        {
            throw new NotSupportedException();
        }

        public void CopyTo(Stream target)
        {
            throw new NotSupportedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}