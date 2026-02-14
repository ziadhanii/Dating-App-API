namespace API.Middleware;

public sealed class ExceptionMiddleware(
    RequestDelegate next,
    ILogger<ExceptionMiddleware> logger,
    IHostEnvironment env)
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        logger.LogError(
            exception,
            "Unhandled exception occurred. TraceId: {TraceId}",
            context.TraceIdentifier
        );

        context.Response.Clear();

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        var response = CreateResponse(statusCode, exception);

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response, JsonOptions)
        );
    }

    private ApiException CreateResponse(
        int statusCode,
        Exception exception)
        => env.IsDevelopment()
            ? new ApiException(
                statusCode,
                exception.Message,
                exception.StackTrace
            )
            : new ApiException(
                statusCode,
                "An unexpected error occurred.",
                null
            );


    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,

            KeyNotFoundException => (int)HttpStatusCode.NotFound,

            ArgumentException => (int)HttpStatusCode.BadRequest,

            _ => (int)HttpStatusCode.InternalServerError
        };
    }
}