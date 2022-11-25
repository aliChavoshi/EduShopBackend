using Application.Common.Mapping;
using Domain.Entities.Identity;

namespace Application.Dtos.Account;

public class AddressDto : IMapFrom<Address>
{
    public int Id { get; set; }
    public bool IsMain { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string FirstName { get; set; }
    public string FullAddress { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }
}