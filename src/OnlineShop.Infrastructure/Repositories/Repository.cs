using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Common;

namespace OnlineShop.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    private readonly IApplicationDbContext _context;
    private readonly DbSet<T> _set;

    protected Repository(DbSet<T> set, IApplicationDbContext context)
    {
        _set = set;
        _context = context;
    }

    public virtual async Task<T> GetAsync(int id)
    {
        return await _set.FirstOrDefaultAsync(entity => entity.Id == id) ??
               throw new ArgumentException($"Entity with provided ID = {id} does not exist");
    }

    public virtual Task<IQueryable<T>> GetAsync()
    {
        return Task.FromResult(_set.AsQueryable());
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        var entry = await _set.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        var entry = _set.Update(entity);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public virtual async Task DeleteAsync(int id)
    {
        _set.Remove(await _set.FirstOrDefaultAsync(entity => entity.Id == id) ??
                    throw new ArgumentException($"Entity with provided ID = {id} does not exist"));
        await _context.SaveChangesAsync();
    }
}