using Microservice.Discount.API.Repositories;

namespace Microservice.Discount.API.Features.Discounts;

public class Discount : BaseEntity
{
    public Guid UserId { get; set; }
    public float Rate { get; set; }
    public string Code { get; set; } = default!;
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }
    
    public DateTime ExpiresAt { get; set; }
}