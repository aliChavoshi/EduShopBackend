using Application.Common.Mapping;
using Domain.Entities.Order;
using Domain.Enums;

namespace Application.Dtos.OrderDto;

public class PortalDto : IMapFrom<Portal>
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public PortalType Gateway { get; set; } 
    public PaymentDataStatus Status { get; set; } 
    public DateTime CreatedOn { get; set; } 
    public long Amount { get; set; }
    public string ReferenceId { get; set; }
}