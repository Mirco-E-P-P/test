﻿using CashBusiness.Application.Services.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace CashBusiness.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOperationService, OperationServiceImpl>();
        return services;
    }
}