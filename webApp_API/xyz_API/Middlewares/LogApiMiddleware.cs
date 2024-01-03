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
        LogRequest(context);

        await _next(context);
    }


    private void LogRequest(HttpContext context)
    {
        //var environment = _configuration.GetValue<string>("Environment");

        var logFilePath = _configuration.GetValue<string>($"Serilog:WriteTo:0:Args:path");

        //var environmentLogFolder = environment == "Production" ? "Logs/Production" : "Logs/Development";
        //var adjuctedLogFilePath = Path.Combine(environmentLogFolder, logFilePath);

        var ipAddress = context.Connection.RemoteIpAddress;
        var url = context.Request.Path;
        var queryMethods = context.Request.Method;

        var logMsg = $"----->   |   IP address: {ipAddress}   |   - URL: {url}   |   - Query methods: {queryMethods}   |    - Server response code: {context.Response.StatusCode}  --->";

        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Minute)
            .CreateLogger();

        Log.Information(logMsg);
    }

}
