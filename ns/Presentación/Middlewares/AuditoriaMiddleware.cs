namespace Ecommerce.Presentación.Middlewares
{
    //Middleware Auditoria
    public class AuditoriaMiddleware
    {
        private readonly RequestDelegate _request;

        public AuditoriaMiddleware(RequestDelegate request)
        {
            _request = request;
        }
        public async Task Invoke(HttpContext context) 
        {
            Console.WriteLine(
                $"{DateTime.Now} - {context.Request.Method} - {context.Request.Path}"
                );

            await _request(context);
        }
    }
}
