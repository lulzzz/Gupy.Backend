 namespace Gupy.Core.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string fieldName, string errorMessage) : base(fieldName, errorMessage)
        {
        }
    }
}