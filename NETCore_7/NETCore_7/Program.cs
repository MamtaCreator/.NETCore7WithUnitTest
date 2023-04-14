using NETCore_7.CustomMiddleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// middleware1
app.Use(async (HttpContext context, RequestDelegate next)
    =>
{
    await context.Response.WriteAsync("Hello"); 
    await next(context); // this will start the next middleware 

});
// middleware2
//app.UseMiddleware<MyCustomMiddleware>();
  app.UseMyCustomMiddleWare();

// middleware3
app.Run(async(HttpContext context) =>{
    await context.Response.WriteAsync("Hello again");  // termination middleware so no next is required 
});
