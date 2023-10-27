using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBusiness.Infraestructure.config;

public class CustomerConfig: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id).IsClustered(false);
        
        builder.HasIndex(customer => customer.Index).IsUnique().IsClustered();
        builder.Property(customer => customer.Index).ValueGeneratedOnAdd();
        
        builder.Property(customer => customer.Name).IsRequired();
        builder.Property(customer => customer.PhoneNumber).HasMaxLength(30);
    }
}