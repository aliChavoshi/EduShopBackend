using Application.Interfaces;
using Domain.Entities.BasketEntity;
using StackExchange.Redis;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Infrastructure.Services;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _redis;

    public BasketRepository(IConnectionMultiplexer redis)
    {
        _redis = redis.GetDatabase();
    }

    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
        var data = await _redis.StringGetAsync(basketId);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
        var newValue =
            await _redis.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),
                TimeSpan.FromDays(1)); //update old data
        if (!newValue) return null;
        return await GetBasketAsync(basket.Id); //return new value
    }

    public async Task<bool> DeleteBasketAsync(string basketId)
    {
        return await _redis.KeyDeleteAsync(basketId);
    }
}