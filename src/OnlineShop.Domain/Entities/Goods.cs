using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities;

[Index(nameof(ArticleNumber), IsUnique = true)]
public class Goods : Entity
{
    public sbyte ArticleNumber { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}