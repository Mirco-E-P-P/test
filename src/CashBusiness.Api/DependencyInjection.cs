using CashBusiness.Api.Commons.Mapping;

namespace CashBusiness.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapping();
        
        return services;
    }
}