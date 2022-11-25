using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class User : IdentityUser
{
    public string DisplayName { get; set; }
    public string NationalCode { get; set; }

    public List<Address> Addresses { get; set; }
    public ICollection<UserRole> UserRole { get; set; }
}