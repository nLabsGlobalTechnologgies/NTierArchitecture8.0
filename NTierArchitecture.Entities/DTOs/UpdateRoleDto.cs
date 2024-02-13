namespace NTierArchitecture.Entities.DTOs;

public sealed record UpdateRoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
