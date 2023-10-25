using CashBusiness.Application.Services.Customer.Commands;
using CashBusiness.Application.Services.Customer.Queries;
using CashBusiness.Application.Services.Transaction;
using CashBusiness.Application.Services.Transaction.Commands;
using CashBusiness.Application.Services.Transaction.Queries;
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