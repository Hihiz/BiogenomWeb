using BiogenomWeb.Domain.Entities;

namespace BiogenomWeb.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория витаминов.
    /// </summary>
    public interface IVitaminRepository
    {
        /// <summary>
        /// Метод получает список витаминов.
        /// </summary>
        /// <returns>Список витаминов.</returns>
        Task<IEnumerable<VitaminEntity>> GetVitaminsAsync();

        /// <summary>
        /// Метод получает витамин по Id витамина.
        /// </summary>
        /// <param name="vitaminId"></param>
        /// <returns>Витамин.</returns>
        Task<VitaminEntity> GetVitaminByVitaminIdAsync(int vitaminId);

        /// <summary>
        /// Метод создает витамин
        /// </summary>
        /// <param name="title">Название витамина.</param>
        Task CreateVitaminAsync(string title);

        /// <summary>
        /// Метод редактирует витамин.
        /// </summary>
        /// <param name="vitaminId">Id витамина.</param>
        /// <param name="title">Название витамина.</param>
        Task UpdateVitaminAsync(int vitaminId, string title);

        /// <summary>
        /// Метод удаляет витамин.
        /// </summary>
        /// <param name="vitaminId">Id витамина.</param>
        Task RemoveVitaminAsync(int vitaminId);
    }
}
