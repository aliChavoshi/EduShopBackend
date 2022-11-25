using Domain.Exceptions;
using System.Net;
using System.Text.Json;
using Exception = System.Exception;

namespace Web.Middleware;

public class MiddlewareExceptionHandler
{
    private readonly IWebHostEnvironment _env;
    private readonly ILoggerFactory _logger;
    private readonly RequestDelegate _next;

    public MiddlewareExceptionHandler(IWebHostEnvironment env, ILoggerFactory logger, RequestDelegate next)
    {
        _env = env;
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); //request send if get error call catch
        }
        catch (Exception exception)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            //create default
            var result = HandleServerError(context, exception, options);
            //change
            result = HandleResult(context, exception, result, options);

            await context.Response.WriteAsync(result);
        }
    }

    private static string HandleServerError(HttpContext context, Exception exception, JsonSerializerOptions options)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500
        var result = JsonSerializer.Serialize(new ApiToReturn(500, exception.Message), options);
        return result;
    }

    private static string HandleResult(HttpContext context, Exception exception, string result,
        JsonSerializerOptions options)
    {
        switch (exception)
        {
            case NotFoundEntityException notFoundException:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                result = JsonSerializer.Serialize(new ApiToReturn(404, notFoundException.Message,
                    notFoundException.Messages, exception.Message), options);
                break;
            case BadRequestEntityException badRequestException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new ApiToReturn(400, badRequestException.Message,
                    badRequestException.Messages, exception.Message), options);
                break;
            case ValidationEntityException validationEntityException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new ApiToReturn(400, validationEntityException.Message,
                    validationEntityException.Messages, exception.Message), options);
                break;
        }

        return result;
    }
}