using Serilog;

namespace xyz_API.Middlewares;

public class LogApiMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public LogApiMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            LogRequest(context);
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsync(ex.ToString());
        }
        

        await _next(context);
    }


    private void LogRequest(HttpContext context)
    {

        var logFilePath = _configuration.GetValue<string>($"Serilog:WriteTo:0:Args:path");

        var ipAddress = context.Connection.RemoteIpAddress;
        var url = context.Request.Path;
        var queryMethods = context.Request.Method;

        var parameters = context.Request.Query;
        var paramsQuery = string.Join(",", parameters.Select(x => $"{x.Key}: {x.Value}"));

        var logMsg = $"----->   |   IP address: {ipAddress}   |   - URL: {url}   |   - Query methods: {queryMethods}   |    - Server response code: {context.Response.StatusCode}  --->   |   - Query parameters: {paramsQuery}";

        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Minute)
            .CreateLogger();

        Log.Information(logMsg);
    }

}
