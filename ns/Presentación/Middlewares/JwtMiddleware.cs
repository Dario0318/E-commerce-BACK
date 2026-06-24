namespace Ecommerce.Presentación.Middlewares
{
    //Validamos que exista un token
    public class JwtMiddleware
    {
        private readonly RequestDelegate _request;

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Headers["Authorization"]
                            .FirstOrDefault()?
                            .Split(" ")
                            .Last();
            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Mensaje = "Token no enviado"
                    });
            }

            await _request(context);
        }
    }
}
