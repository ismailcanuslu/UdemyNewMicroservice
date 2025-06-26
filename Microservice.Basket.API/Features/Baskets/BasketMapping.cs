using AutoMapper;
using Microservice.Basket.API.Data;
using Microservice.Basket.API.Dto;

namespace Microservice.Basket.API.Features.Baskets;

public class BasketMapping : Profile
{
    public BasketMapping()
    {
        CreateMap<Data.Basket, BasketDto>().ReverseMap();
        CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        CreateMap<BasketItemDto, BasketItem>().ReverseMap();
    }
}