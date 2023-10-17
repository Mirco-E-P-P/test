using CashBusiness.Infraestructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CashBusiness.Infraestructure;


public class DependecyIntection
{

    public static  IServiceCollection AddInfraestructure(this IServiceCollection services){
        services.AddDbContext<AppDbContext>( );

    }

    
}


