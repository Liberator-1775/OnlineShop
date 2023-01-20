using Microsoft.OpenApi.Models;
using OnlineShop.Application;
using OnlineShop.Infrastructure;
using OnlineShop.WebUI.Models;

namespace OnlineShop.WebUI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddMvc().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new PatchRequestContractResolver();
        });
        services.AddApplicationServices();
        services.AddInfrastructureServices(Configuration);
        services.AddWebUiServices();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Shop", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Shop v1"));
        }

        app.UseRouting();

        app.UseEndpoints(builder => { builder.MapControllers(); });
    }
}