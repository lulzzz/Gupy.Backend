using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Gupy.Core.Common;
using Gupy.Core.Interfaces.Common;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Gupy.Business.Commands.Exports
{
    public class ExportOrdersCommand : IRequest<IFile>
    {
    }

    public class ExportOrdersCommandHandler : IRequestHandler<ExportOrdersCommand, IFile>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHostEnvironment _environment;

        public ExportOrdersCommandHandler(IOrderRepository orderRepository, IHostEnvironment environment)
        {
            _orderRepository = orderRepository;
            _environment = environment;
        }

        public async Task<IFile> Handle(ExportOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.ListAsync();

            var templatePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "files", "templates",
                "ReportTemplate.xlsx");
            var template = new FileInfo(templatePath);

            using (var package = new ExcelPackage(template))
            {
                var sheet = package.Workbook.Worksheets[0];

                var i = 2;
                var index = 1;
                foreach (var order in orders)
                {
                    sheet.Cells[$"A{i}"].Value = index;
                    sheet.Cells[$"B{i}"].Value = order.Id;

                    sheet.Cells[$"C{i}:D{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[$"C{i}:D{i}"].Value = order.DateOrdered;
                    
                    sheet.Cells[$"E{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[$"E{i}:F{i}"].Value = order.DateShipped;
                    
                    sheet.Cells[$"C{i}:F{i}"].Style.Numberformat.Format = "mm/dd/yyyy hh:mm:ss";

                    
                    sheet.Cells[$"G{i}"].Value = order.OrderStatus;

                    var color = order.OrderStatus switch
                    {
                        OrderStatus.Pending => Color.DodgerBlue,
                        OrderStatus.Completed => Color.LimeGreen,
                        OrderStatus.Cancelled => Color.Red,
                        _ => throw new ArgumentException()
                    };
                    sheet.Cells[$"G{i}"].Style.Font.Color.SetColor(color);

                    sheet.Cells[$"H{i}"].Value = order.TotalSum;
                    sheet.Cells[$"H{i}"].Style.Numberformat.Format = "0.00";

                    ++i;
                    ++index;
                }

                var excelData = package.GetAsByteArray();
                return new ExcelFile($"Orders Export - {DateTime.UtcNow:dd-mm-yyy hh-mm-ss}.xlsx", excelData);
            }
        }
    }
}