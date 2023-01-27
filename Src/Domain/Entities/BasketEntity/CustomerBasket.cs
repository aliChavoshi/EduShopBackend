namespace Domain.Entities.BasketEntity;

public class CustomerBasket
{
    public CustomerBasket(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    public List<CustomerBasketItem> Items { get; set; } = new();

    public decimal CalculateOriginalPrice()
    {
        return Items.Sum(x => x.Price * x.Quantity);
    }
}