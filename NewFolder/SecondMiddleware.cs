namespace MyCustomMiddleware.NewFolder;

public class SecondMiddleware 
{
    private readonly RequestDelegate _next;

    public SecondMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Second Middleware is Called");
        await context.Response.WriteAsync("Second Middleware is Called \n");
        await _next(context);
         await context.Response.WriteAsync("After second Middleware is Called \n");
    }
}
public static class Configure1
{
    public static IApplicationBuilder UseSecondMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SecondMiddleware>();
    }
}
