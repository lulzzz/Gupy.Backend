using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Reports
{
    public class CreateReportCommand : IRequest<ReportDto>
    {
        public string Message { get; set; }
        public ReportType ReportType { get; set; }

        public int TelegramUserId { get; set; }
    }

    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ReportDto>
    {
        private readonly IReportRepository _reportRepository;
        private readonly ITelegramUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateReportCommandHandler(IReportRepository reportRepository, ITelegramUserRepository userRepository,
            IMapper mapper)
        {
            _reportRepository = reportRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report
            {
                Message = request.Message,
                DateReported = DateTime.UtcNow,
                ReportType = request.ReportType,
                TelegramUserId = request.TelegramUserId
            };

            var user = await _userRepository.GetAsync(report.TelegramUserId);
            if (user == null)
            {
                throw new NotValidException(nameof(report.TelegramUserId),
                    $"Telegram User with id ({report.TelegramUserId}) does not exist");
            }

            await _reportRepository.AddAsync(report);
            await _reportRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<ReportDto>(report);
            return result;
        }
    }
}