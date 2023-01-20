using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Domain.Entities.Goods> Goods { get; }

    public DbSet<Order> Orders { get; }

    public DbSet<OrderGoods> OrderGoods { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}