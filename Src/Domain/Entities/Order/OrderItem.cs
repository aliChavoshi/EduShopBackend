using Domain.Entities.Base;

namespace Domain.Entities.Order;

public class OrderItem : BaseEntity
{
    public ProductItemOrdered ItemOrdered { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}