using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Common.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Persistence;
using OnlineShop.Infrastructure.Repositories;

namespace OnlineShop.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseNpgsql(configuration.GetConnectionString("Default")))
            .AddScoped<IApplicationDbContext, ApplicationDbContext>()
            .AddTransient<IRepository<Goods>, GoodsRepository>()
            .AddTransient<IRepository<Order>, OrderRepository>();
    }
}