using DoctorNow.Domain.SharedKernel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DoctorNow.Presentation.Common.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var errorDetails = Error.Failure(
                "Error.InternalServerError",
                "An error occurred while processing the request.");
            
            logger.LogError(exception,
                $"An unknown error occurred while processing the request: {exception.Message}");
            
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            
            await context.Response.WriteAsJsonAsync(errorDetails);
        }
    }
}