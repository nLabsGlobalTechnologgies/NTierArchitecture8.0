using Microsoft.AspNetCore.Identity;

namespace NTierArchitecture.Entities.Models;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = new byte[64];
    public byte[] PasswordSalt { get; set; } = new byte[128];
}
