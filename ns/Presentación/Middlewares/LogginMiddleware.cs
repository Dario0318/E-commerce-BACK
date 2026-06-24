namespace Ecommerce.Presentación.Middlewares
{
    //Registra todas las peticiones
    public class LogginMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<LogginMiddleware> _logger;

        public LogginMiddleware(RequestDelegate request, ILogger<LogginMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("{Method} {Path}", 
                context.Request.Method,
                context.Request.Path);

            await _request(context);
        }
    }
}
