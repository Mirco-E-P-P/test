using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashBusiness.Infraestructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Concept>().HasKey(concept => concept.Id);
        modelBuilder.Entity<Operation>().HasIndex(operation => operation.Id);
        
    }

    public DbSet<Operation> Operations { get; set; }
    public DbSet<Concept> Concepts { get; set; }
}


