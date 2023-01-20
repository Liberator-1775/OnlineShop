using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Application.Orders.Interfaces;
using OnlineShop.Application.Orders.Models;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Application.Orders;

public class OrderFacade : IOrderFacade
{
    private readonly IMapper _mapper;
    private readonly IRepository<Order> _orderRepository;

    public OrderFacade(IRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> GetAllRegisteredAsync()
    {
        return _mapper.Map<List<OrderDto>>(
            (await _orderRepository.GetAsync()).Include(order => order.Goods)
            .ThenInclude(goods => goods.Goods)
            .Where(order => order.OrderStatus.Equals(OrderStatus.Registered)));
    }

    public async Task<OrderDto> GetByOrderNumberAsync(short orderNumber)
    {
        return _mapper.Map<OrderDto>(
            await (await _orderRepository.GetAsync()).Include(order => order.Goods)
                .ThenInclude(goods => goods.Goods)
                .FirstOrDefaultAsync(order => order.OrderNumber == orderNumber));
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto order)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(order);
        if (!Validator.TryValidateObject(order, context, results, true))
            throw new ValidationException(results.FirstOrDefault()!.ErrorMessage);
        return _mapper.Map<OrderDto>(await _orderRepository.CreateAsync(_mapper.Map<Order>(order)));
    }

    public async Task<OrderDto> UpdateAsync(OrderDto order)
    {
        var orderDb = await _orderRepository.GetAsync(order.Id);
        if (orderDb.OrderStatus != OrderStatus.Registered)
            throw new ArgumentException("Order can be edited only in status \"Registered\"");
        return _mapper.Map<OrderDto>(await _orderRepository.UpdateAsync(_mapper.Map<Order>(order)));
    }

    public async Task<OrderDto> PatchAsync(PatchOrderDto order)
    {
        var orderDb = await (await _orderRepository.GetAsync()).Include(o => o.Goods)
            .ThenInclude(goods => goods.Goods)
            .FirstOrDefaultAsync(o => o.Id == order.Id);

        if (orderDb == null) throw new ArgumentException($"Order with id {order.Id} does not exist");

        if (orderDb.OrderStatus != OrderStatus.Registered)
            throw new ArgumentException("Order can be edited only in status \"Registered\"");

        orderDb.OrderNumber = order.IsFieldPresent(nameof(orderDb.OrderNumber))
            ? order.OrderNumber
            : orderDb.OrderNumber;
        orderDb.OrderStatus = order.IsFieldPresent(nameof(orderDb.OrderStatus))
            ? order.OrderStatus
            : orderDb.OrderStatus;
        orderDb.Goods = order.IsFieldPresent(nameof(orderDb.Goods))
            ? _mapper.Map<List<OrderGoods>>(order.Goods)
            : orderDb.Goods;
        orderDb.CustomerFullName = order.IsFieldPresent(nameof(orderDb.CustomerFullName))
            ? order.CustomerFullName
            : orderDb.CustomerFullName;

        return _mapper.Map<OrderDto>(await _orderRepository.UpdateAsync(orderDb));
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepository.GetAsync(id);
        if (order.OrderStatus != OrderStatus.Registered)
            throw new ArgumentException("Order can be deleted only in status \"Registered\"");
        await _orderRepository.DeleteAsync(id);
    }

    public async Task<List<OrderDto>> GetByRegistrationDateAsync(DateOnly date)
    {
        return _mapper.Map<List<OrderDto>>(
            (await _orderRepository.GetAsync()).Include(order => order.Goods)
            .ThenInclude(goods => goods.Goods)
            .Where(order => order.RegistrationDate == date));
    }
}