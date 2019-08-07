using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AppCore
{
    public class MainMiddleware
    {
        private RequestDelegate _next;
        public MainMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($" Hello MainMiddleware!");
            await _next(context);
        }
    }
}
