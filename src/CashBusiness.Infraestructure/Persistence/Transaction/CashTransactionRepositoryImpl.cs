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


    public async Task<CashTransaction> PersistCashTransaction(string clientId, string voucher, string operationId, double amount, string observation)
    {
        var cashTransaction = new CashTransaction
        {
            ClientId = clientId, 
            Voucher = voucher, 
            OperationId = operationId, 
            Amount = amount, 
            Observation = observation
        };

        EntityEntry<CashTransaction> savedTransaction = _dbContext.Add(cashTransaction);
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