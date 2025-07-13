using BiogenomWeb.Application.Interfaces.Services;
using BiogenomWeb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomWeb.Api.Controllers
{
    /// <summary>
    /// Контроллер отчета диагностики.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="reportService">Сервис отчета диагностики.</param>
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Метод получает отчет последней диагностики.
        /// /// </summary>
        /// <returns>Отчет диагностики.</returns>
        [HttpGet]
        [Route("report")]
        public async Task<IActionResult> GetReportsAsync()
        {
            IEnumerable<VitaminReportEntity> result = await _reportService.GetReportsAsync();

            return Ok(result);
        }
    }
}
