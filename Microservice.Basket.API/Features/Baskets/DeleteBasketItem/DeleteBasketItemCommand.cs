using Microservice.Shared;

namespace Microservice.Basket.API.Features.Baskets.DeleteBasketItem;

public record DeleteBasketItemCommand(Guid Id): IRequestByServiceResult;