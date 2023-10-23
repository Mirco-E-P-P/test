using CashBusiness.Application.Common.Persistence.Transaction;
using CashBusiness.Domain.Entity;
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

    public Task<CashTransaction> FindCashTransactionById()
    {
        throw new NotImplementedException();
    }

    public Task<List<CashTransaction>> FindAllTransactions()
    {
        throw new NotImplementedException();
    }
}