﻿using Gupy.Core.Common;

 namespace Gupy.Core.Exceptions
{
    public class NotValidException : ExceptionBase
    {
        public NotValidException(string fieldName, string errorMessage) : base(fieldName, errorMessage)
        {
        }
    }
}