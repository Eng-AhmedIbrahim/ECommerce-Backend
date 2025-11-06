namespace Ecommerce.Api.Base.Errors;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;

    public ApiResponse(int statusCode, string? message = null)
    {
        this.StatusCode = statusCode;
        this.Message = message ?? GetDefaultStatusCodeMessage(this.StatusCode) ?? default!;
    }

    private static string? GetDefaultStatusCodeMessage(int statusCode)
    {
        return statusCode switch
        {
            400 => "A Bad Request, You have made",
            401 => "Authorized, you are not",
            404 => "Resource was not found",
            500 => "Internal Server Error.",
            _ => null
        };
    }
}