namespace Microservice.Shared.Services;

public class IdentityServiceFake : IIdentityService
{
    public Guid GetUserId => Guid.Parse("b38d7a9c-f086-4459-8a0b-276b12b418a8");
    public string UserName => "beemo4";
}