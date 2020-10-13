using System;
using Gupy.Domain;

namespace Gupy.Core.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateReported { get; set; }
        public ReportType ReportType { get; set; }

        public int TelegramUserId { get; set; }
    }
}