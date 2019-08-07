using Microsoft.AspNetCore.Builder;

namespace AppCore
{
    public static class AppCoreExtensions
    {
        public static IApplicationBuilder UseMainMiddleware(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<MainMiddleware>();
        }

        public static IApplicationBuilder UseSecondaryMiddleware(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<SecondaryMiddleware>();
        }
    }
}
