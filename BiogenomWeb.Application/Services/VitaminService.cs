using BiogenomWeb.Application.Interfaces.Repositories;
using BiogenomWeb.Application.Interfaces.Services;
using BiogenomWeb.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BiogenomWeb.Application.Services
{
    /// <summary>
    /// Класс реализует методы сервиса витаминов.
    /// </summary>
    public class VitaminService : IVitaminService
    {
        private readonly IVitaminRepository _vitaminRepository;
        private readonly ILogger<VitaminService> _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="vitaminRepository">Репозитория витаминов.</param>
        /// <param name="logger">Логгер.</param>
        public VitaminService(IVitaminRepository vitaminRepository,
            ILogger<VitaminService> logger)
        {
            _vitaminRepository = vitaminRepository;
            _logger = logger;
        }

        #region Публичные методы.

        /// <inheritdoc />
        public async Task<IEnumerable<VitaminEntity>> GetVitaminsAsync()
        {
            try
            {
                IEnumerable<VitaminEntity> result = await _vitaminRepository.GetVitaminsAsync();

                return result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<VitaminEntity> GetVitaminByVitaminIdAsync(int vitaminId)
        {
            try
            {
                if (vitaminId <= 0)
                {
                    throw new InvalidOperationException($"Недопустимый Id витамина. VitaminId: {vitaminId}.");
                }

                VitaminEntity result = await _vitaminRepository.GetVitaminByVitaminIdAsync(vitaminId);

                if (result is null)
                {
                    return new VitaminEntity();
                }

                return result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task CreateVitaminAsync(string title)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new InvalidOperationException("Недопустимое название витамина. " +
                                                        $"Title: {title}.");
                }

                await _vitaminRepository.CreateVitaminAsync(title);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task UpdateVitaminAsync(int vitaminId, string title)
        {
            try
            {
                if (vitaminId <= 0)
                {
                    throw new InvalidOperationException($"Недопустимый Id витамина. VitaminId: {vitaminId}.");
                }

                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new InvalidOperationException("Недопустимое название витамина. " +
                                                        $"Title: {title}.");
                }

                await _vitaminRepository.UpdateVitaminAsync(vitaminId, title);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task RemoveVitaminAsync(int vitaminId)
        {
            try
            {
                if (vitaminId <= 0)
                {
                    throw new InvalidOperationException($"Недопустимый Id витамина. VitaminId: {vitaminId}.");
                }

                await _vitaminRepository.RemoveVitaminAsync(vitaminId);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion

        #region Приватные методы.

        #endregion       
    }
}
