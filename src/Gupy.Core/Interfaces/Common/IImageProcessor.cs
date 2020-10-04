namespace Gupy.Core.Interfaces.Common
{
    /// <summary>
    /// Image processor
    /// </summary>
    public interface IImageProcessor
    {
        /// <summary>
        /// Resizes image
        /// </summary>
        /// <param name="photo"></param>
        /// <returns>Resized image stored as a byte array</returns>
        byte[] ResizeImage(IFile photo);
    }
}