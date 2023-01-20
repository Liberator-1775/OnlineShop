using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Goods> Goods => Set<Goods>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderGoods> OrderGoods => Set<OrderGoods>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderGoods>().HasKey(goods => new { goods.GoodsId, goods.OrderId });
    }
}