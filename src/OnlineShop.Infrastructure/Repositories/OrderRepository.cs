using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>
{
    private readonly IApplicationDbContext _context;

    public OrderRepository(IApplicationDbContext context) : base(context.Orders, context)
    {
        _context = context;
    }

    public override Task<Order> CreateAsync(Order entity)
    {
        _context.Goods.AttachRange(entity.Goods.Select(goods => goods.Goods).Where(goods => goods.Id != 0));
        return base.CreateAsync(entity);
    }

    public override Task<Order> UpdateAsync(Order entity)
    {
        _context.Goods.AttachRange(entity.Goods.Select(goods => goods.Goods).Where(goods => goods.Id != 0));
        return base.UpdateAsync(entity);
    }
}