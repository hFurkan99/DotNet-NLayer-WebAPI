using Microsoft.Extensions.DependencyInjection;
using App.Services.Products;

namespace App.Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
