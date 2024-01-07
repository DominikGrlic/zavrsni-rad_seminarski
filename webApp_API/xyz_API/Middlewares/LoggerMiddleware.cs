using Serilog;

namespace xyz_API.Middlewares;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggerMiddleware> _logger;

    public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        foreach(var item in context.Request.Query)
        {
            _logger.LogInformation($"Query parameter: {item.Key} = {item.Value}");
        }

        foreach(var item in context.Request.RouteValues)
        {
            _logger.LogInformation($"Router parameter {item.Key} = {item.Value}");
        }

        var ipAdress = context.Connection.RemoteIpAddress;
        var url = context.Request.Path;

        _logger.LogInformation($"Ip address: {ipAdress}");
        _logger.LogInformation($"URL: {url}");

        await _next(context);
    }

}
