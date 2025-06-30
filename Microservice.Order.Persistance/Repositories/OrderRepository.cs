using Microservice.Order.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Order.Persistance.Repositories;

public class OrderRepository(AppDbContext context) : GenericRepository<Guid,Domain.Entities.Order>(context), IOrderRepository
{
    public async Task <List<Domain.Entities.Order>> GetOrdersByUserIdAsync(Guid buyerId)
    {
        return await context.Orders.Include(x => x.OrderItems)
            .Include(x => x.Address).Where(x => x.BuyerId == buyerId)
            .OrderByDescending(x => x.CreatedDateTime).ToListAsync();
    }
}