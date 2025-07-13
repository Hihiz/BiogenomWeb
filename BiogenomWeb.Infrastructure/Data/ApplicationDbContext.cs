using BiogenomWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWeb.Infrastructure.Data
{
    /// <summary>
    /// Класс контекста EF Core.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RecomendationProductEntity> RecomendationProducts { get; set; }

        public DbSet<ReportEntity> Reports { get; set; }

        public DbSet<VitaminEntity> Vitamins { get; set; }

        public DbSet<VitaminReportEntity> VitaminReports { get; set; }     
    }
}
