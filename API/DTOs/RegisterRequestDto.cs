
namespace API.DTOs;

public class RegisterRequestDto
{
    [Required]
    
    public string DisplayName { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";
}
