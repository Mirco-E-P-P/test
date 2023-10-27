using CashBusiness.Application.Services.CashTransactionServices.Commands;
using CashBusiness.Application.Services.CashTransactionServices.Queries;
using CashBusiness.Application.Services.CustomerServices.Commands;
using CashBusiness.Application.Services.CustomerServices.Queries;
using CashBusiness.Application.Services.OperationServices.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CashBusiness.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOperationQueryService, OperationQueryService>();
        services.AddScoped<ICustomerCommandService, CustomerCommandService>();
        services.AddScoped<ICustomerQueryService, CustomerQueryService>();
        
        services.AddScoped<ICashTransactionCommandService, CashTransactionCommandService>();
        services.AddScoped<ICashTransactionQueryService, CashTransactionQueryService>();
        
        return services;
    }
}