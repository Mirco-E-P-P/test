using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBusiness.Infraestructure.config;

public class OperationConfig: IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(nameof(Operation.Index), nameof(Operation.Id));
        builder.Property(operation => operation.Index).ValueGeneratedOnAdd();
    }
}