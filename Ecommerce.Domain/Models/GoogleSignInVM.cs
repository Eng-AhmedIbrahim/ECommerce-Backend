using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models;

public class GoogleSignInVM
{
    [Required]
    public string IdToken { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
}