using System.Text.Json;
using MediatR;
using Microservice.Basket.API.Const;
using Microservice.Basket.API.Dto;
using Microservice.Shared;
using Microservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Microservice.Basket.API.Features.Baskets.AddBasketItem;

public class AddBasketCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        Guid userId = identityService.GetUserId;
        var cacheKey = String.Format(BasketConst.BasketCacheKey, userId);

        var basketAsString = await distributedCache.GetStringAsync(cacheKey,cancellationToken);

        BasketDto? currentBasket;

        var newBasketItem = new BasketItemDto(
            request.CourseId, request.CourseName,
            request.ImageUrl, request.CoursePrice, null);

        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket= new BasketDto(userId, [newBasketItem]);
            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
        
        currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

        var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);

        if (existingBasketItem is not null)
        {
            // TODO : business rule
            currentBasket.BasketItems.Remove(existingBasketItem);
                
        }
            
        currentBasket.BasketItems.Add(newBasketItem);

        await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);
        
        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(BasketDto basket, string cacheKey, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);
            
        await distributedCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);
    }
}