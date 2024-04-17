namespace MyCustomMiddleware.NewFolder;

public class FirstMiddleware
{
    private readonly RequestDelegate _next;

    public FirstMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("First Middleware is Called");
        await context.Response.WriteAsync("First Middleware is Called \n");
        await _next(context);
        await context.Response.WriteAsync("After First Middleware is Called \n");
    }
}

public static class Configure
{
    public static IApplicationBuilder UseFirstMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FirstMiddleware>();
    }
}
