namespace NTierArchitecture.Entities.DTOs;
public sealed record LoginResponseDto
{
    public Guid UserId { get; set; }
    public string AccessToken { get; set; } = string.Empty;
}
