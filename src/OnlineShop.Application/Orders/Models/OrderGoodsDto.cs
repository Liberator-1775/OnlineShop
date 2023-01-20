using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.Goods.Models;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Orders.Models;

public class OrderGoodsDto : IMap<OrderGoods>
{
    public GoodsDto Goods { get; set; }

    public byte Count { get; set; }
}