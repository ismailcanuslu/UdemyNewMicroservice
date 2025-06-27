namespace Microservice.Discount.API.Options;

public class MongoOptions
{
    public string DatabaseName { get; set; } = default!;
    public string ConnectionString { get; set; } = default!;
}