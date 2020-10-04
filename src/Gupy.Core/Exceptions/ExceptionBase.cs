using System;
using Gupy.Core.Common;

namespace Gupy.Core.Exceptions
{
    public class ExceptionBase : Exception
    {
        public Error Error { get; }

        public ExceptionBase(string fieldName, string errorMessage)
        {
            Error = new Error(fieldName, errorMessage);
        }
    }
}