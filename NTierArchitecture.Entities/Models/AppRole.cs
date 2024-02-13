using Microsoft.AspNetCore.Identity;

namespace NTierArchitecture.Entities.Models;
public sealed class AppRole : IdentityRole<Guid>
{
    public string Name { get; set; } = string.Empty;
}
