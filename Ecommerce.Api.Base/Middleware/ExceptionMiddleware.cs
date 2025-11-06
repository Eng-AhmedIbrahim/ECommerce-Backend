namespace Ecommerce.Api.Base.Middleware;

public class ExceptionMiddleware
{
    private RequestDelegate? next { get; set; }
    private ILogger<ExceptionMiddleware>? logger { get; set; }
    private IHostEnvironment? env { get; set; }

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        this.next = next;
        this.logger = logger;
        this.env = env;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next?.Invoke(httpContext)!;
        }
        catch (Exception ex)
        {
            logger!.LogError(ex, ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = env!.IsDevelopment() ?
               new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString()) :
               new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);

            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await httpContext.Response.WriteAsync(json);
        }

    }
}