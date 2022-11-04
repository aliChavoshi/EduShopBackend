using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class User : IdentityUser
{
    public string DisplayName { get; set; }

    public List<Address> Addresses { get; set; }
}