using System.Text.Json.Serialization;

namespace Microservice.Basket.API.Data;

public class Basket
{
    //anemic model buradaki classic hali sadece data -- rich domain model ise (behavior + data)
    public Guid UserId { get; set; }

    public List<BasketItem> Items { get; set; } = new();

    public float? DiscountRate { get; set; }
    public string? Coupon { get; set; }
    
    [JsonIgnore] public bool IsApplyDiscount => DiscountRate > 0 && !string.IsNullOrEmpty(Coupon);
    
    [JsonIgnore] public decimal TotalPrice => Items.Sum(x => x.Price);

    [JsonIgnore] public decimal? TotalPriceWithAppliedDiscount
    {
        get
        {
            return !IsApplyDiscount ? null : Items.Sum(x => x.PriceByApplyDiscountRate);
        }
    }

    public Basket()
    {
        
    }
    public Basket(Guid userId, List<BasketItem> items)
    {
        UserId = userId;
        Items = items;
    }

    

    public void ApplyNewDiscount(string coupon, float discountRate)
    {
        Coupon = coupon;
        DiscountRate = discountRate;

        foreach (var basket in Items)
        {
            basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - discountRate);
        }
    }
    
    public void ApplyAvailableDiscount()
    {
        if (!IsApplyDiscount)
        {
            return;
        }
        foreach (var basket in Items)
        {
            basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - DiscountRate!);
        }
    }

    public void ClearDiscount()
    {
        DiscountRate = null;
        Coupon = null;
        foreach (var basket in Items)
        {
            basket.PriceByApplyDiscountRate = null;
        }
    }
}