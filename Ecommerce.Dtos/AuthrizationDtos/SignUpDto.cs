namespace Ecommerce.Dtos.AuthrizationDtos;

public class SignUpDto
{
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public bool HasAcceptedTerms { get; set; }
    [Required]
    public string Password { get; set; } = string.Empty;
    public IFormFile? ProfilePicture { get; set; }
}