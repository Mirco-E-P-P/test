using CashBusiness.Application.Common.Persistence.Transaction;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CashBusiness.Infraestructure.Persistence.Transaction;

public class CashTransactionRepositoryImpl: ICashTransactionRepository
{
    private readonly AppDbContext _dbContext;
    
    public CashTransactionRepositoryImpl(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<CashTransaction> PersistCashTransaction(CashTransaction cashTransaction)
    {
        EntityEntry<CashTransaction> savedTransaction = _dbContext.CashTransactions.Add(cashTransaction);
        await _dbContext.SaveChangesAsync();
        return savedTransaction.Entity;
    }

    public async Task<CashTransaction> FindCashTransactionById(Guid id)
    {
        try
        {
            CashTransaction findTransaction = await _dbContext.CashTransactions.Where(cashTransaction => cashTransaction.Id == id)
                .FirstAsync();
            
            return findTransaction;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<List<CashTransaction>> FindAllTransactions()
    {
        return await _dbContext.CashTransactions.ToListAsync();
    }
}