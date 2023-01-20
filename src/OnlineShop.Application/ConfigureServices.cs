using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Goods;
using OnlineShop.Application.Goods.Interfaces;
using OnlineShop.Application.Orders;
using OnlineShop.Application.Orders.Interfaces;

namespace OnlineShop.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddTransient<IGoodsFacade, GoodsFacade>()
            .AddTransient<IOrderFacade, OrderFacade>();
    }
}