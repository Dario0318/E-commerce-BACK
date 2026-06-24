namespace Ecommerce.Presentación.Middlewares
{
    //Middleware de excepciones 
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        
        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Exito = false,
                        Mensaje = ex.Message
                    });
            }
        }
    }
}
