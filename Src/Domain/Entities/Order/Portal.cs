using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities.Order;

public class Portal : BaseEntity
{
    public Portal(int orderId, PortalType gateway, PaymentDataStatus status, long amount, string referenceId)
    {
        OrderId = orderId;
        Gateway = gateway;
        Status = status;
        Amount = amount;
        ReferenceId = referenceId;
    }
    public int OrderId { get; set; }
    public PortalType Gateway { get; set; } = PortalType.Zarrinpal;
    public PaymentDataStatus Status { get; set; } = PaymentDataStatus.Pending;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public long Amount { get; set; }

    public string ReferenceId { get; set; }

    //relation
    public Order Order { get; set; }
}