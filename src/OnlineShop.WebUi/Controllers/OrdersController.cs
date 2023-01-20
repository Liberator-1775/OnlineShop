using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Orders.Interfaces;
using OnlineShop.Application.Orders.Models;

namespace OnlineShop.WebUI.Controllers;

[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderFacade _orderFacade;

    public OrdersController(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }

    [HttpGet]
    public async Task<List<OrderDto>> GetAllRegisteredAsync()
    {
        return await _orderFacade.GetAllRegisteredAsync();
    }

    [HttpGet("{orderNumber}")]
    public async Task<OrderDto> GetByOrderNumberAsync(short orderNumber)
    {
        return await _orderFacade.GetByOrderNumberAsync(orderNumber);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateOrderDto order)
    {
        try
        {
            return Ok(await _orderFacade.CreateAsync(order));
        }
        catch (DbUpdateException e)
        {
            return BadRequest(e.InnerException?.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] OrderDto order)
    {
        try
        {
            return Ok(await _orderFacade.UpdateAsync(order));
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (DbUpdateException e)
        {
            return BadRequest(e.InnerException?.Message);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> PatchAsync([FromBody] PatchOrderDto order)
    {
        try
        {
            return Ok(await _orderFacade.PatchAsync(order));
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (DbUpdateException e)
        {
            return BadRequest(e.InnerException?.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _orderFacade.DeleteAsync(id);
            return Ok();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("forDate/{date}")]
    public async Task<List<OrderDto>> GetByRegistrationDateAsync(DateOnly date)
    {
        return await _orderFacade.GetByRegistrationDateAsync(date);
    }
}