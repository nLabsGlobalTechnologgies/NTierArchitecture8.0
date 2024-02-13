using System.ComponentModel.DataAnnotations;

namespace NTierArchitecture.Entities.Models;
public class UserRole
{
    [Key]
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }

    [Key]
    public Guid RoleId { get; set; }
    public AppRole? Role { get; set; }
}

