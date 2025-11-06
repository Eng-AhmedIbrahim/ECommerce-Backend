namespace Ecommerce.Api.Base.Errors;

public class ApiValidationErrorResponse(IEnumerable<string> errors) : ApiResponse(400)
{
    public IEnumerable<string> Errors { get; } = errors;
}