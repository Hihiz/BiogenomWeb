using BiogenomWeb.Application.Interfaces.Services;
using BiogenomWeb.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BiogenomWeb.Application
{
    /// <summary>
    /// Класс регистрирует зависимости в контейнере.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Метод добавляет инициализацию сервисов слоя Application в коллекцию сервисов.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Коллекция зарегистрированных сервисов.</returns>
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.ServicesInit();

            return services;
        }

        /// <summary>
        /// Метод регистрирует сервисы.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        private static void ServicesInit(this IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
