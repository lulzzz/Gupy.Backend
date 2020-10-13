using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.Report.CreateReport
{
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
            var report = _mapper.Map<Domain.Report>(request.ReportDto);
            report.DateReported = DateTime.UtcNow;

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