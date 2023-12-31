﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CashBusiness.Infraestructure.Persistence;

public class CashTransactionRepositoryImpl: ICashTransactionRepository
{
    private readonly AppDbContext _dbContext;
    
    public CashTransactionRepositoryImpl(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<CashTransaction> PersistCashTransactionAsync(CashTransaction cashTransaction)
    {
        EntityEntry<CashTransaction> savedTransaction = await _dbContext.CashTransactions.AddAsync(cashTransaction);
        await _dbContext.SaveChangesAsync();
        return savedTransaction.Entity;
    }

    public async Task<CashTransaction> FindCashTransactionByIdAsync(Guid id)
    {
        try
        {
            CashTransaction findTransaction = await _dbContext.CashTransactions.Where(cashTransaction => cashTransaction.Id == id)
                .AsNoTracking().FirstAsync();
            
            return findTransaction;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<CashTransaction>> FindAllTransactionsAsync()
    {
        return await _dbContext.CashTransactions.ToListAsync();
    }

    public async Task<CashTransaction> UpdateCashTransactionAsync(CashTransaction cashTransaction)
    {
        _dbContext.Update(cashTransaction);
        _dbContext.Entry(cashTransaction).Property(c => c.Index).IsModified = false;
        _dbContext.Entry(cashTransaction).Property(c => c.CreatedAt).IsModified = false;
        _dbContext.Entry(cashTransaction).Property(c => c.UpdatedAt).IsModified = false;
        
        await _dbContext.SaveChangesAsync();
        return cashTransaction;
    }

    public async Task<int> DeleteCashTransactionByIdAsync(Guid id)
    {
        int affectedRows =  await _dbContext.CashTransactions.Where(cashTransaction => cashTransaction.Id == id).ExecuteDeleteAsync();
        return affectedRows;
    }
}