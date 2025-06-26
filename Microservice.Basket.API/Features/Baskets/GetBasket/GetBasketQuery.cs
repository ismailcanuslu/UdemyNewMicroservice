using Microservice.Basket.API.Dto;
using Microservice.Shared;

namespace Microservice.Basket.API.Features.Baskets.GetBasket;

public record GetBasketQuery : IRequestByServiceResult<BasketDto>;