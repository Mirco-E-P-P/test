using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBusiness.Infraestructure.config;

public class OperationConfig: IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(operation => operation.Id).IsClustered(false);
        
        builder.HasIndex(operation => operation.Index).IsUnique().IsClustered();
        builder.Property(operation => operation.Index).ValueGeneratedOnAdd();
    }
}