using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace TeachLink_BackEnd.Infrastructure.GlobalHendelrs
{
    public class HandlerGlobalExeptions : IExceptionHandler
    {
        private readonly ILogger<HandlerGlobalExeptions> _logger;

        public HandlerGlobalExeptions(ILogger<HandlerGlobalExeptions> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            var (statusCode, message) = GetExceptionDetails(exception);

            _logger.LogError(exception, exception.Message);

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(message, cancellationToken);

            return true;
        }

        private (HttpStatusCode statusCode, string message) GetExceptionDetails(Exception exception)
        {
            return exception switch
            {
                BadRequestException => (HttpStatusCode.BadRequest, exception.Message),
                NotFoundException => (HttpStatusCode.NotFound, exception.Message),
                _ => (
                    HttpStatusCode.InternalServerError,
                    $"An unexpected error occurred: {exception.Message}"
                ),
            };
        }
    }
}
