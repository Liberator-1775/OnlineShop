using OnlineShop.Application.Goods.Models;

namespace OnlineShop.Application.Goods.Interfaces;

public interface IGoodsFacade
{
    Task<List<GoodsDto>> GetAllAsync();

    Task<GoodsDto> GetByArticleNumberAsync(sbyte articleNumber);
}