/* using Microsoft.AspNetCore.Diagnostics;

namespace MovieLibraryServer.Domain.Exceptions.Handlers;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";
        var excDetails = exception switch
        {
            ValidationException => 
                (Detail: exception.Message, StatusCode: StatusCodes.Status422UnprocessableEntity),
                _ => (Detail: exception.Message, StatusCode: StatusCodes.Status500InternalServerError)
        };
        httpContext.Response.StatusCode = excDetails.StatusCode;
        if (exception is ValidationException validationException)
        {
           await httpContext.Response.WriteAsJsonAsync(new { validationException.Errors }, cancellationToken);
           return true;
        }

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
            {
                Title = "An error occured>>",
                Detail = excDetails.Detail,
                Type = exception.GetType().Name,
                Status = excDetails.StatusCode
            },
            Exception = exception
        });
    }
} */