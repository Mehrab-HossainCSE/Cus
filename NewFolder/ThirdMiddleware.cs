namespace MyCustomMiddleware.NewFolder;

public class ThirdMiddleware 
{
  private readonly RequestDelegate _next;

    public ThirdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Third Middleware is Called");
        await context.Response.WriteAsync("Third Middleware is Called \n");
        await _next(context);
         await context.Response.WriteAsync("After Third Middleware is Called \n");
    }
}
public static class Configure2
{
    public static IApplicationBuilder UseThirdMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ThirdMiddleware>();
    }
}