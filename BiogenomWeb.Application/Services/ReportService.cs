using BiogenomWeb.Application.Interfaces.Repositories;
using BiogenomWeb.Application.Interfaces.Services;
using BiogenomWeb.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BiogenomWeb.Application.Services
{
    /// <summary>
    /// Класс реализует методы сервиса отчета диагностики.
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportService> _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="reportRepository">Репозиторий отчетов диагностики.</param>
        /// <param name="logger">Логгер.</param>
        public ReportService(IReportRepository reportRepository,
           ILogger<ReportService> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<VitaminReportEntity>> GetReportsAsync()
        {
            try
            {
                IEnumerable<VitaminReportEntity> result = await _reportRepository.GetReportsAsync();

                return result;  
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
