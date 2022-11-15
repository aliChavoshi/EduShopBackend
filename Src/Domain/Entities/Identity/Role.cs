using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class Role : IdentityRole<string>
{
    public ICollection<UserRole> UserRole { get; set; }
}