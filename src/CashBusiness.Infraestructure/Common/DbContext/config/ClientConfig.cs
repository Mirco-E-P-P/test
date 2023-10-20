using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBusiness.Infraestructure.config;

public class ClientConfig: IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(client => client.Id);
        builder.Property(client => client.Name).IsRequired();
        builder.Property(client => client.PhoneNumber).HasMaxLength(30);
    }
}