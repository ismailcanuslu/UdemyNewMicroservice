using System.Text.Json.Serialization;

namespace Microservice.Basket.API.Dto;

public record BasketDto
{
    [JsonIgnore] public bool IsApplyDiscount => DiscountRate > 0 && !string.IsNullOrEmpty(Coupon);

    public List<BasketItemDto> Items { get; set; } = new();
    
    public float? DiscountRate { get; set; }
    public string? Coupon { get; set; }
    
   public decimal TotalPrice => Items.Sum(x => x.Price);

    public decimal? TotalPriceWithAppliedDiscount
    {
        get
        {
            return !IsApplyDiscount ? null : Items.Sum(x => x.PriceByApplyDiscountRate);
        }
    }
    public BasketDto(List<BasketItemDto> items) 
    {
 
        Items = items;
    }

    public BasketDto()
    {
        
    }

}

