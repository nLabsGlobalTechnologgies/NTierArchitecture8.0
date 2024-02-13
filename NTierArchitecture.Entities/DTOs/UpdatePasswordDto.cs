namespace NTierArchitecture.Entities.DTOs;

public sealed record UpdatePasswordDto
{
    public Guid Id { get; set; }
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string ReNewPassword { get; set; } = string.Empty;
}
