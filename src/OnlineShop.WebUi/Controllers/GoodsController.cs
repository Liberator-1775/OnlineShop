using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Goods.Interfaces;
using OnlineShop.Application.Goods.Models;

namespace OnlineShop.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodsController : ControllerBase
{
    private readonly IGoodsFacade _goodsFacade;

    public GoodsController(IGoodsFacade goodsFacade)
    {
        _goodsFacade = goodsFacade;
    }

    [HttpGet]
    public async Task<List<GoodsDto>> GetAllAsync()
    {
        return await _goodsFacade.GetAllAsync();
    }

    [HttpGet("{articleNumber}")]
    public async Task<GoodsDto> GetByArticleNumberAsync([Required] sbyte articleNumber)
    {
        
        return await _goodsFacade.GetByArticleNumberAsync(articleNumber);
    }
}