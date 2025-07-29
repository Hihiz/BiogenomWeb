namespace BiogenomWeb.Api.Middlewares
{
    /// <summary>
    /// Класс прехвата и обработки исключений.
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

        /// <summary>
        /// Метод перехвата запроса.
        /// </summary>
        /// <param name="context">Контекст запроса.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
    }
}
