﻿using System.Collections.Immutable;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBusiness.Infraestructure.config;

public class CashTransactionConfig: IEntityTypeConfiguration<CashTransaction>
{
    public void Configure(EntityTypeBuilder<CashTransaction> builder)
    {
        builder.HasKey(cashTransaction => cashTransaction.Id).IsClustered(false);
        
        builder.HasIndex(cashTransaction => cashTransaction.Index).IsUnique().IsClustered();
        builder.Property(cashTransaction => cashTransaction.Index).ValueGeneratedOnAdd();
        
        builder.Property(cashTransaction => cashTransaction.Amount).HasColumnType("decimal(10,2)");
        builder.Property(cashTransaction => cashTransaction.CreatedAt).HasColumnType("date");
        builder.Property(cashTransaction => cashTransaction.UpdatedAt).HasColumnType("date");
    }
}