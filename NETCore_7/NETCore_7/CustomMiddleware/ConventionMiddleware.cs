using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace NETCore_7.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConventionMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionMiddleware>();
        }
    }
}
