using Domain.Entities.Base;

namespace Domain.Entities.Identity;

public class Address : BaseEntity
{
    public string UserId { get; set; }
    public bool IsMain { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string FullAddress { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }

    #region Relations

    public User User { get; set; }

    #endregion
}