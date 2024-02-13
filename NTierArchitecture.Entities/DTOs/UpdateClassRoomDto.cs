using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Entities.DTOs;

public sealed record UpdateClassRoomDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Student>? Students { get; set; }
}
