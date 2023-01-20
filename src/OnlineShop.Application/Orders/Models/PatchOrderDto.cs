using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.Common.Models;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Application.Orders.Models;

public class PatchOrderDto : PatchDto, IMap<Order>
{
    public short OrderNumber { get; set; }

    public string CustomerFullName { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public List<OrderGoodsDto> Goods { get; set; }
}