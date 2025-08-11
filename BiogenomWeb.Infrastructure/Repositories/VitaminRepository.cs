using BiogenomWeb.Application.Interfaces.Repositories;
using BiogenomWeb.Domain.Entities;
using BiogenomWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BiogenomWeb.Infrastructure.Repositories
{
    /// <summary>
    /// Класс реализует методы репозитория витаминов.
    /// </summary>
    public class VitaminRepository : IVitaminRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="db">Класс контекста.</param>
        public VitaminRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Публичные методы.
        /// <inheritdoc />
        public async Task RemoveVitaminAsync(int vitaminId)
        {
            int row = await _db.Vitamins
                     .Where(v => v.Id == vitaminId)
                     .ExecuteDeleteAsync();

            if (row <= 0)
            {
                throw new InvalidOperationException("Ошибка при удалении витамина. " +
                                                    $"VitaminId: {vitaminId}.");
            }
        }

        #endregion

        #region Приватные методы.

        #endregion        
    }
}
