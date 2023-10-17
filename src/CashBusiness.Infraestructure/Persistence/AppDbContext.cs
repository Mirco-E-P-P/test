using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashBusiness.Infraestructure.Persistence;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Concept>().HasKey(concept => concept.id);
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    // public DbSet<User> Users { get; set; }
    // public DbSet<CashTransaction> CashTransactions { get; set; }
    // public DbSet<Operation> Operations { get; set; }
    public DbSet<Concept> Concepts { get; set; }
    // public DbSet<Currency> Currencies { get; set; }

}


