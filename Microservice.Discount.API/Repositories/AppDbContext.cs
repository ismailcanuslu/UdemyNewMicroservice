using System.Reflection;
using MongoDB.Driver;

namespace Microservice.Discount.API.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
{

    public DbSet<Features.Discounts.Discount> Discounts { get; set; }
    public static AppDbContext Create(IMongoDatabase database)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(database.Client,
                database.DatabaseNamespace.DatabaseName);
        
        return new AppDbContext(optionsBuilder.Options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}