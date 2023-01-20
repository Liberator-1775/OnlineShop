using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Repositories;

public class GoodsRepository : Repository<Goods>
{
    public GoodsRepository(IApplicationDbContext context) : base(context.Goods, context)
    {
    }
}