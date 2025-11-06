namespace Ecommerce.Api.Base.Extensions;

public static class GlobalExceptionHandler
{
    public static void HandelException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(o => o.Run(async context =>
        {
            var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exceptions = errorFeature!.Error;

            if (!(exceptions is ValidationException validationException))
                throw exceptions;

            var erros =
            validationException.Errors.Select(e => new
            {
                Property = e.PropertyName,
                Message = e.ErrorMessage
            });

            var errorContent = JsonSerializer.Serialize(erros);

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(errorContent,Encoding.UTF8);
        }));
    }
}