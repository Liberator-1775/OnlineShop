using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Domain.Entities;

[Index(nameof(OrderNumber), IsUnique = true)]
public class Order : Entity
{
    public short OrderNumber { get; set; }

    public string CustomerFullName { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public ICollection<OrderGoods> Goods { get; set; }

    public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
}