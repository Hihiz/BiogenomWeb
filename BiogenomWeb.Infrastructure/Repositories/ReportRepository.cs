using BiogenomWeb.Application.Interfaces.Repositories;
using BiogenomWeb.Domain.Entities;
using BiogenomWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWeb.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализует методы репозитория отчета диагностики.
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="db">Класс контекста.</param>
        public ReportRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<VitaminReportEntity>> GetReportsAsync()
        {
            IEnumerable<VitaminReportEntity> result = await _db.VitaminReports
                 .AsNoTracking()
                 .Include(v => v.Report)
                 .Include(v => v.Vitamin)
                 .Where(v => v.ReportId ==
                     _db.Reports
                     .OrderByDescending(r => r.CreatedAt)
                     .FirstOrDefault()!.Id)
                 .ToListAsync();

            return result;

        }
    }
}
