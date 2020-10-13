using Gupy.Domain;

namespace Gupy.Api.Models.Report
{
    public class CreateReportModel
    {
        public string Message { get; set; }
        public ReportType ReportType { get; set; }
        public int TelegramUserId { get; set; }
    }
}