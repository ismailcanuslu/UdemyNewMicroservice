using System.Net;
using System.Text.Json;
using MediatR;
using Microservice.Basket.API.Const;
using Microservice.Basket.API.Dto;
using Microservice.Shared;
using Microservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Microservice.Basket.API.Features.Baskets.DeleteBasketItem;

public class DeleteBasketItemCommandHandler(BasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
    {

        var basketAsJson = await basketService.GetBasketFromCacheAsync(cancellationToken);

        if (string.IsNullOrEmpty(basketAsJson))
        {
            return ServiceResult.Error("Basket item not found",HttpStatusCode.NotFound);
        }

        var currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

        var basketItemToDelete = currentBasket!.Items.FirstOrDefault(x => x.Id == request.Id);

        if (basketItemToDelete is null)
        {
            return ServiceResult.Error("Basket item not found",HttpStatusCode.NotFound);
        }

        currentBasket.Items.Remove(basketItemToDelete);
        
        basketAsJson = JsonSerializer.Serialize(currentBasket);
        await basketService.CreateBasketCacheAsync( currentBasket , cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}