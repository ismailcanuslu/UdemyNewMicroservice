using System.Text.Json;
using Microservice.Basket.API.Const;
using Microservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Microservice.Basket.API.Features.Baskets;

public class BasketService(IIdentityService identityService, IDistributedCache distributedCache)
{
    private string GetCacheKey() => string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);
    
    public async Task<string?> GetBasketFromCacheAsync(CancellationToken cancellationToken)
    {
        return await distributedCache.GetStringAsync(GetCacheKey(),cancellationToken);
    }
    
    public async Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);
        await distributedCache.SetStringAsync(GetCacheKey(), basketAsString, cancellationToken);
    }
}