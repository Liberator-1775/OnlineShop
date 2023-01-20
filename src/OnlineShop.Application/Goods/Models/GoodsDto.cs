using OnlineShop.Application.Common.Mappings;
using OnlineShop.Application.Common.Models;

namespace OnlineShop.Application.Goods.Models;

public class GoodsDto : EntityDto, IMap<Domain.Entities.Goods>
{
    public sbyte ArticleNumber { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}