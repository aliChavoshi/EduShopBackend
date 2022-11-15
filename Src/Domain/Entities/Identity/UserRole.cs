using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class UserRole : IdentityUserRole<string>
{
    public UserRole(string roleId,string userId)
    {
        RoleId = roleId;
        UserId = userId;
    }

    public UserRole()
    {
        
    }

    public User User { get; set; }
    public Role Role { get; set; }
}