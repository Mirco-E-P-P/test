using CashBusiness.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CashBusiness.Application.UnitTests.Services.Transaction.ServiceUtils;

public class InMemoryApplicationDatabase
{
    private static InMemoryApplicationDatabase Instance;

    private static string DatabaseName = Guid.NewGuid().ToString();
    
    private static DbContextOptions<AppDbContext> DbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(DatabaseName)
        .Options;
    
    private static AppDbContext Context = new AppDbContext(DbContextOptions);
    
    private InMemoryApplicationDatabase()
    { }

    public static InMemoryApplicationDatabase GetInstance()
    {
        if (Instance == null)
        {
            Instance = new InMemoryApplicationDatabase();
        }
        return Instance;
    }

    public AppDbContext GetApplicationDbContext()
    {
        return Context;
    }
    
}