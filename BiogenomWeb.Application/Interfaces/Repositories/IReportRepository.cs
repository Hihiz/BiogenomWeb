using BiogenomWeb.Domain.Entities;

namespace BiogenomWeb.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория отчета диагностики.
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// Метод получает отчет последней диагностики.
        /// </summary>
        /// <returns>Отчет диагностики.</returns>
        Task<IEnumerable<VitaminReportEntity>> GetReportsAsync();
    }
}
