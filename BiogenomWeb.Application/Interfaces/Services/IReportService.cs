using BiogenomWeb.Domain.Entities;

namespace BiogenomWeb.Application.Interfaces.Services
{
    /// <summary>
    /// Интерфейс сервиса отчета диагностики.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Метод получает отчет последней диагностики.
        /// /// </summary>
        /// <returns>Отчет диагностики.</returns>
        Task<IEnumerable<VitaminReportEntity>> GetReportsAsync();
    }
}
