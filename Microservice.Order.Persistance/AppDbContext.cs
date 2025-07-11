using Microservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Order.Persistance;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{

    public DbSet<Domain.Entities.Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Address> Addresses { get; set; }

     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceAssembly).Assembly);


        base.OnModelCreating(modelBuilder);
    }
}