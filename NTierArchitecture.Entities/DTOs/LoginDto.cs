
namespace NTierArchitecture.Entities.DTOs;
public sealed record LoginDto
{
    public string UserNameOrEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = true;
}
