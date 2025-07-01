using AutoMapper;
using Microservice.Order.Application.Features.Orders.CreateOrder;

namespace Microservice.Order.Application.Features.Orders;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Domain.Entities.Order, OrderItemDto>().ReverseMap();
    }
}