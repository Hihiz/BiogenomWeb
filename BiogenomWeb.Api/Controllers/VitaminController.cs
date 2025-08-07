using BiogenomWeb.Application.Dto.Input.Vitamin;
using BiogenomWeb.Application.Interfaces.Services;
using BiogenomWeb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomWeb.Api.Controllers
{
    /// <summary>
    /// Контроллер витаминов.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VitaminController : ControllerBase
    {
        private readonly IVitaminService _vitaminService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="vitaminService">Сервис витаминов.</param>
        public VitaminController(IVitaminService vitaminService)
        {
            _vitaminService = vitaminService;
        }

        /// <summary>
        /// Метод получает список витаминов.
        /// </summary>
        /// <returns>Список витаминов.</returns>
        [HttpGet]
        [Route("vitamins")]
        public async Task<IActionResult> GetVitaminsAsync()
        {
            IEnumerable<VitaminEntity> result = await _vitaminService.GetVitaminsAsync();

            return Ok(result);
        }

        /// <summary>
        /// Метод получает витамин по Id витамина.
        /// </summary>
        /// <param name="vitaminId">Id витамина.</param>
        /// <returns>Витамин.</returns>
        [HttpGet]
        [Route("vitamin")]
        public async Task<IActionResult> GetVitaminByVitaminIdAsync([FromQuery] int vitaminId)
        {
            VitaminEntity result = await _vitaminService.GetVitaminByVitaminIdAsync(vitaminId);

            return Ok(result);
        }

        /// <summary>
        /// Метод создает витамин
        /// </summary>
        /// <param name="title">Название витамина.</param>
        [HttpPost]
        [Route("vitamin")]
        public async Task CreateVitaminAsync([FromBody] string title)
        {
            await _vitaminService.CreateVitaminAsync(title);
        }

        /// <summary>
        /// Метод редактирует витамин.
        /// </summary>
        /// <param name="updateVitaminInput">Метод редактирует витамин.</param>
        [HttpPut]
        [Route("vitamin")]
        public async Task UpdateVitaminAsync([FromBody] UpdateVitaminInput updateVitaminInput)
        {
            await _vitaminService.UpdateVitaminAsync(updateVitaminInput.Id, updateVitaminInput.Title!);
        }

        /// <summary>
        /// Метод удаляет витамин.
        /// </summary>
        /// <param name="vitaminId">Id витамина.</param>
        [HttpDelete]
        [Route("vitamin")]
        public async Task RemoveVitaminAsync([FromQuery] int vitaminId)
        {
            await _vitaminService.RemoveVitaminAsync(vitaminId);
        }
    }
}
