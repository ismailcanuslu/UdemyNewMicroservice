namespace Microservice.Shared.Services;

public interface IIdentityService
{
    public Guid GetUserId { get; }
    public string UserName { get; }
}