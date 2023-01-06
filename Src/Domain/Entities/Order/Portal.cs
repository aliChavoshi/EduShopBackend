using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities.Order;

public class Portal : BaseEntity
{
    public int OrderId { get; set; }
    public PortalType Gateway { get; set; } = PortalType.Zarrinpal;
    public PaymentDataStatus Status { get; set; } = PaymentDataStatus.Pending;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public long Amount { get; set; }
    public string ReferenceId { get; set; }
    //relation
    public Order Order { get; set; }
}