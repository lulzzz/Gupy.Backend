using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Common;

namespace Gupy.Core.Common
{
    public class ExcelFile : IFile
    {
        private readonly byte[] _excelData;
        private readonly string _fileName;
        public long Length => _excelData.Length;
        public string FileName => _fileName;

        public ExcelFile(string fileName, byte[] excelData)
        {
            _fileName = fileName;
            _excelData = excelData;
        }

        public Stream OpenReadStream()
        {
            return new MemoryStream(_excelData);
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