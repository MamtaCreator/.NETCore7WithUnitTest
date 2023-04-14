namespace NETCore_7.CustomMiddleware.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom middleware : Start");
            await next(context);
            await context.Response.WriteAsync("Custom middle  : Ends ");
        }

    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();

        }


    }
}
