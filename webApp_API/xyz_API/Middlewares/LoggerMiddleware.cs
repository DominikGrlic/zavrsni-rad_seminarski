using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

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
        // - setting 'token' and 'token handler'
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();

        try
        {
            // - reading from 'token' and getting user name information through 'token claims'
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userName = jsonToken?.Claims.First(claim => claim.Type == ClaimTypes.GivenName).Value;
            
            _logger.LogInformation($"Active user name: {userName}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        var ipAdress = context.Connection.RemoteIpAddress;
        var url = context.Request.Path;
        
        
        _logger.LogInformation($"Ip address: {ipAdress}");
        _logger.LogInformation($"URL: {url}");

        foreach (var item in context.Request.Query)
        {
            _logger.LogInformation($"Query parameter: {item.Key} = {item.Value}");
        }

        foreach(var item in context.Request.RouteValues)
        {
            _logger.LogInformation($"Router parameter {item.Key} = {item.Value}");
        }

        string requestBody = string.Empty;
        if(context.Request.ContentLength > 0)
        {
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();

                try
                {
                    var parsedJson = JToken.Parse(requestBody);
                    _logger.LogInformation($"Request body(json): {parsedJson}");
                }
                catch (JsonReaderException)
                {
                    _logger.LogWarning("[Invalid JSON file!]");
                }

            }
        }

        if(!string.IsNullOrEmpty(requestBody))
        {
            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));
        }

        await _next(context);
    }
}
