using Microservice.Shared;

namespace Microservice.Basket.API.Features.Baskets.AddBasketItem;

public record AddBasketItemCommand(
    Guid CourseId, 
    string CourseName, 
    decimal CoursePrice,
    string? ImageUrl) : IRequestByServiceResult;