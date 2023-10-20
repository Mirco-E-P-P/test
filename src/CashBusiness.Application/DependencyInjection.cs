using CashBusiness.Application.Services.Transaction;
using CashBusiness.Application.Services.Transaction.Queries;
using CashBusiness.Application.Services.User.Commands;
using CashBusiness.Application.Services.User.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CashBusiness.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOperationQueryService, OperationQueryService>();
        services.AddScoped<IClientCommandService, ClientCommandService>();
        services.AddScoped<IClientQueryService, ClientQueryService>();
        return services;
    }
}