using Microservice.Order.Application.Features.Orders.CreateOrder;

namespace Microservice.Order.Application.Features.Orders.GetOrders;

public record GetOrdersResponse(DateTime OrderDateTime, decimal TotalPrice, List<OrderItemDto> Items);