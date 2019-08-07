using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore
{
    public class SecondaryMiddleware
    {
        private RequestDelegate _next;
        public SecondaryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($" Hello SecondaryMiddleware!");
            await _next(context);
        }
    }
}
