namespace Microservice.Basket.API.Dto;

public record BasketDto(
    Guid UserId,
    List<BasketItemDto> BasketItems);