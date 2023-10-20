using CashBusiness.Application.Services.Transaction;
using CashBusiness.Application.Services.Transaction.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CashBusiness.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOperationQueryService, OperationQueryService>();
        return services;
    }
}