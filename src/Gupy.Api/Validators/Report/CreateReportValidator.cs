using FluentValidation;
using Gupy.Business.Commands.Reports;

namespace Gupy.Api.Validators.Report
{
    public class CreateReportValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportValidator()
        {
            RuleFor(r => r.Message).MinimumLength(32).MaximumLength(4096);
            RuleFor(r => r.ReportType).IsInEnum();
            RuleFor(r => r.TelegramUserId).GreaterThan(0);
        }
    }
}