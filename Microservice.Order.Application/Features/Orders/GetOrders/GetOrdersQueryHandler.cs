using AutoMapper;
using MediatR;
using Microservice.Order.Application.Contracts.Repositories;
using Microservice.Order.Application.Features.Orders.CreateOrder;
using Microservice.Shared;
using Microservice.Shared.Services;

namespace Microservice.Order.Application.Features.Orders.GetOrders;

public class GetOrdersQueryHandler(IIdentityService identityService, IOrderRepository orderRepository,IMapper mapper) : IRequestHandler<GetOrdersQuery,ServiceResult<List<GetOrdersResponse>>>
{
    public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetOrdersByUserIdAsync(identityService.GetUserId);

        var response = orders.Select(o =>
            new GetOrdersResponse(o.CreatedDateTime, o.TotalPrice, mapper.Map<List<OrderItemDto>>(o.OrderItems))).ToList();

        return ServiceResult<List<GetOrdersResponse>>.SuccessAsOk(response);

    }
}