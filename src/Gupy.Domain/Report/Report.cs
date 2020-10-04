using System;

namespace Gupy.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateReported { get; set; }
        public ReportType ReportType { get; set; }
        
        public int TelegramUserId { get; set; }
    }
}