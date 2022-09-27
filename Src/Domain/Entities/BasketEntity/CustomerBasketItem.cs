using Domain.Entities.Base;

namespace Domain.Entities.BasketEntity;

public class CustomerBasketItem : BaseEntity
{
    public string Product { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string PictureUrl { get; set; }
}