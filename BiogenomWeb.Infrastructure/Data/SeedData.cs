using BiogenomWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace BiogenomWeb.Infrastructure.Data
{
    /// <summary>
    /// Класс заполняет БД начальными данными.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Метод инициализирует БД начальными данными.
        /// </summary>
        /// <param name="serviceProvider">Провайдер сервисов.</param>
        /// <returns>Признак выполнилась ли инициализация БД.</returns>
        public static async Task<bool> Initializer(IServiceProvider serviceProvider)
        {
            using ApplicationDbContext db = new ApplicationDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (!await db.Database.CanConnectAsync())
            {
                await db.Database.EnsureCreatedAsync();
            }

            using IDbContextTransaction transaction = await db.Database.BeginTransactionAsync(System.Data
                .IsolationLevel.ReadCommitted);

            try
            {
                if (await db.RecomendationProducts.AnyAsync() &&
                    await db.Vitamins.AnyAsync() &&
                    await db.Reports.AnyAsync() &&
                    await db.VitaminReports.AnyAsync())
                {
                    return false;
                }

                List<RecomendationProductEntity> recomendationProducts = new()
            {
                new()
                {
                    Id = 1,
                    Title = "ED Smart"
                },
                 new()
                {
                     Id = 2,
                    Title = "Протектор BioSettings \"Биосеттинг\""
                }
            };

                List<VitaminEntity> vitamins = new()
            {
                new()
                {
                    Id = 1,
                    Title = "Витамин C"
                },
                 new()
                {
                      Id = 2,
                    Title = "Витамин D"
                },
                  new()
                {
                       Id = 3,
                    Title = "Цинк"
                }
            };

                List<ReportEntity> reports = new()
                {
                    new()
                    {
                        Id = 1,
                        CreatedAt = DateTime.UtcNow
                    },
                    new()
                    {
                    Id = 2,
                    CreatedAt = DateTime.UtcNow + TimeSpan.FromDays(1)
                    }
                };

                List<VitaminReportEntity> vitaminReports = new()
                {
                    new()
                    {
                        Id = 1,
                        ReportId = reports[0].Id,
                        VitaminId = vitamins[0].Id,
                        CurrentValue = 7.71M,
                        ReferenceValue = 14,
                        FoodValue = 0,
                        SupplementValue = 7.50M,
                        IsDeficit = false
                    },
                    new()
                    {
                        Id = 2,
                        ReportId = reports[0].Id,
                        VitaminId = vitamins[1].Id,
                        CurrentValue = 3.24M,
                        ReferenceValue = 15,
                        FoodValue = 0,
                        SupplementValue = 7.50M,
                        IsDeficit = true
                    },
                     new()
                    {
                        Id = 3,
                        ReportId = reports[1].Id,
                        VitaminId = vitamins[2].Id,
                        CurrentValue = 7.71M,
                        ReferenceValue = 14,
                        FoodValue = 0,
                        SupplementValue = 7.50M,
                        IsDeficit = false
                    },
                      new()
                    {
                        Id = 4,
                        ReportId = reports[1].Id,
                        VitaminId = vitamins[0].Id,
                        CurrentValue = 38.12M,
                        ReferenceValue = 100,
                        FoodValue = 0,
                        SupplementValue = 7.50M,
                        IsDeficit = true
                    },

                };

                db.RecomendationProducts.AddRange(recomendationProducts);
                db.Vitamins.AddRange(vitamins);
                db.Reports.AddRange(reports);
                db.VitaminReports.AddRange(vitaminReports);

                await db.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
