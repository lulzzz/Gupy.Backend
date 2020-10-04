using System.Threading.Tasks;

namespace Gupy.Core.Interfaces.Common
{
    /// <summary>
    /// Represents a Photo Storage
    /// </summary>
    public interface IPhotoStorage
    {
        /// <summary>
        /// Stores a file
        /// </summary>
        /// <param name="photo"></param>
        /// <returns>Stored Photo FileName</returns>
        Task<string> StorePhotoAsync(IFile photo);

        /// <summary>
        /// Deletes photo with specified fileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True if result was successful</returns>
        Task<bool> DeletePhotoAsync(string fileName);
    }
}