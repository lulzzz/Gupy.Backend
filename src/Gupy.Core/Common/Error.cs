﻿using System.Text.Json;

 namespace Gupy.Core.Common
{
    public class Error
    {
        public string FieldName { get; }
        public string Message { get; }

        public Error(string fieldName, string message)
        {
            FieldName = fieldName;
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this,new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
    }
}