using System.ComponentModel.DataAnnotations;
using OnlineShop.Application.Common.Mappings;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Application.Orders.Models;

public class CreateOrderDto : IMap<Order>, IValidatableObject
{
    public short OrderNumber { get; set; }

    public string CustomerFullName { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public List<OrderGoodsDto> Goods { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Goods.Sum(dto => dto.Count) > 10)
            yield return new ValidationResult("Order cannot contain more than 10 goods");

        if (Goods.Sum(dto => dto.Goods.Price * dto.Count) > 15000)
            yield return new ValidationResult("Order price cannot exceed 15000");
    }
}