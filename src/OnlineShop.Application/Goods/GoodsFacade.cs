using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Application.Goods.Interfaces;
using OnlineShop.Application.Goods.Models;

namespace OnlineShop.Application.Goods;

public class GoodsFacade : IGoodsFacade
{
    private readonly IRepository<Domain.Entities.Goods> _goodsRepository;
    private readonly IMapper _mapper;

    public GoodsFacade(IRepository<Domain.Entities.Goods> goodsRepository, IMapper mapper)
    {
        _goodsRepository = goodsRepository;
        _mapper = mapper;
    }

    public async Task<List<GoodsDto>> GetAllAsync()
    {
        return _mapper.Map<List<GoodsDto>>(await _goodsRepository.GetAsync());
    }

    public async Task<GoodsDto> GetByArticleNumberAsync(sbyte articleNumber)
    {
        return _mapper.Map<GoodsDto>(
            await (await _goodsRepository.GetAsync()).FirstOrDefaultAsync(goods =>
                goods.ArticleNumber == articleNumber));
    }
}