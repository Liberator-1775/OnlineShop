using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities;

public class OrderGoods
{
    public int GoodsId { get; set; }

    [ForeignKey(nameof(GoodsId))] public Goods Goods { get; set; }

    public int OrderId { get; set; }

    [ForeignKey(nameof(OrderId))] public Order Order { get; set; }

    public byte Count { get; set; }
}