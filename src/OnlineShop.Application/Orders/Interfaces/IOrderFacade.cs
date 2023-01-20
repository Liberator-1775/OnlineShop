using OnlineShop.Application.Orders.Models;

namespace OnlineShop.Application.Orders.Interfaces;

public interface IOrderFacade
{
    Task<List<OrderDto>> GetAllRegisteredAsync();

    Task<OrderDto> GetByOrderNumberAsync(short orderNumber);

    Task<OrderDto> CreateAsync(CreateOrderDto order);

    Task<OrderDto> UpdateAsync(OrderDto order);

    Task<OrderDto> PatchAsync(PatchOrderDto order);

    Task DeleteAsync(int id);

    Task<List<OrderDto>> GetByRegistrationDateAsync(DateOnly date);
}