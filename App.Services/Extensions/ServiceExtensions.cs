﻿using Microsoft.Extensions.DependencyInjection;
using App.Services.Products;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace App.Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
