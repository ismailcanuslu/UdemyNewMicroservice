namespace Microservice.Discount.API.Features.Discounts.GetDiscountByCode;

public record GetDiscountByCodeQuery(string Code) : IRequestByServiceResult<GetDiscountByCodeQueryResponse>;