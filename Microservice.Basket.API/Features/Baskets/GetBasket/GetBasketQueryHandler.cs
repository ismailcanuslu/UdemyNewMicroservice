using System.Net;
using System.Text.Json;
using AutoMapper;
using MediatR;
using Microservice.Basket.API.Const;
using Microservice.Basket.API.Dto;
using Microservice.Shared;
using Microservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Microservice.Basket.API.Features.Baskets.GetBasket;

public class GetBasketQueryHandler(IMapper mapper,BasketService basketService)
    : IRequestHandler<GetBasketQuery,ServiceResult<BasketDto>>
{
    public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basketAsJson = await basketService.GetBasketFromCacheAsync(cancellationToken);

        if (string.IsNullOrEmpty(basketAsJson))
        {
            return ServiceResult<BasketDto>.Error("Basket not found",HttpStatusCode.NotFound);
        }
        
        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

        var basketDto = mapper.Map<BasketDto>(basket);

        return ServiceResult<BasketDto>.SuccessAsOk(basketDto);
    }
}