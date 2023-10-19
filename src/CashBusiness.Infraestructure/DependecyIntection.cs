using CashBusiness.Application.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using CashBusiness.Infraestructure.Persistence;
using CashBusiness.Infraestructure.Persistence.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace CashBusiness.Infraestructure;

public static class DependecyIntection
{
    public static  IServiceCollection AddInfraestructure(this IServiceCollection services){
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer("Server=DESKTOP-2TTGTQJ;Database=SisCashBusinessDB;Integrated Security=True; TrustServerCertificate=True",
                b => b.MigrationsAssembly("CashBusiness.Api")));

        services.AddScoped<IOperationRepository, OperationRepositoryImpl>();
        
        return services;

    }

}


