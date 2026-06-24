using System.Diagnostics;

namespace Ecommerce.Presentación.Middlewares
{
    //Este Middleware mide el rendimiento
    public class TiempoEjecucionMiddleware
    {
        private readonly RequestDelegate _request;
        public TiempoEjecucionMiddleware(RequestDelegate request) 
        { 
            _request = request;
        }

        public async Task Invoke(HttpContext context) 
        { 
            Stopwatch sw = Stopwatch.StartNew();

            await _request(context);

            sw.Stop();

            Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
        }
    }
}
