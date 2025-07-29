namespace BiogenomWeb.Api.Middlewares
{
    /// <summary>
    /// Класс прехвата и обработки ошибок.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="next">Запрос.</param>
        /// <param name="logger">Логгер.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next, 
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
    }
}
