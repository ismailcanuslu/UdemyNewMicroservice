using System.Linq.Expressions;
using Microservice.Order.Application.Contracts.Repositories;
using Microservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Order.Persistance.Repositories;

public class GenericRepository<TId, TEntity>(AppDbContext context) : IGenericRepository<TId, TEntity> where TId : struct where TEntity : BaseEntity<TId> 
{
    protected AppDbContext Context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
   
    public Task<bool> AnyAsync(TId id)
    {
        return _dbSet.AnyAsync(x => x.Id.Equals(id));
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AnyAsync(predicate);
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }

    public Task<List<TEntity>> GetAllPaged(int pageNumber, int pageSize)
    {
        return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public ValueTask<TEntity?> GetByIdAsync(TId id)
    {
        return _dbSet.FindAsync(id);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}