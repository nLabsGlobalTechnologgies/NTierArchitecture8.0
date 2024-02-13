using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Entities.DTOs;
public sealed record CreateClassRoomDto
{
    public string Name { get; set; } = string.Empty;
    public List<Student>? Students { get; set; }
}
