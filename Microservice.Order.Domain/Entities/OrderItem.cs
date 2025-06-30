namespace Microservice.Order.Domain.Entities;


public class OrderItem : BaseEntity<int>
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public decimal UnitPrice { get; set; }

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = default!;
    
    //behavior methods, bu methodlar anemic modelimizi rich domain model haline getiriyor.

    public void SetItem(Guid productId, string productName, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(ProductName))
        {
            throw new ArgumentException("Product cannot be empty",nameof(ProductName));
        }

        if (UnitPrice <= 0)
        {
            throw new ArgumentException("Unit price cannot be less than or equal to zero",nameof(unitPrice));
        }
        
        this.ProductId = productId;
        this.ProductName = productName;
        this.UnitPrice = unitPrice;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
        {
            throw new ArgumentException("Price cannot be less than or equal to zero");
        }
        this.UnitPrice = newPrice;
    }

    public void ApplyDiscount(float discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentException("Discount percentage must be between 0 and 100");
        }
        this.UnitPrice -= (this.UnitPrice * (decimal)discountPercentage / 100);
    }

    public bool IsSameItem(OrderItem otherItem)
    {
        return this.ProductId == otherItem.ProductId;
    }
    
}