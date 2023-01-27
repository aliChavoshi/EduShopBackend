using Domain.Entities.Base;
using Domain.Entities.Identity;
using Domain.Enums;

namespace Domain.Entities.Order;

public class Order : BaseAuditableEntity
{
    public string BuyerPhoneNumber { get; set; }

    public decimal SubTotal { get; set; }

    //order status
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public string TrackingCode { get; set; }

    //portal
    public Portal Portal { get; set; }
    public PortalType PortalType { get; set; } = PortalType.Zarrinpal;
    public bool IsFinally { get; set; } = false; // default is false after order change to true or false
    public string Authority { get; set; } //TODO

    public decimal GetOriginalTotal()
    {
        return SubTotal + DeliveryMethod.Price;
    }

    public List<OrderItem> OrderItems { get; set; } = new();
    public ShipToAddress ShipToAddress { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
    public User User { get; set; }
}