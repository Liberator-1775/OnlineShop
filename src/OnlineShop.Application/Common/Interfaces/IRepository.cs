using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Common.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<T> GetAsync(int id);

    Task<IQueryable<T>> GetAsync();

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(int id);
}