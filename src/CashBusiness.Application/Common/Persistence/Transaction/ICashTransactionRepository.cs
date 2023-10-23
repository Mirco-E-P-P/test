using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.Transaction;

public interface ICashTransactionRepository
{
    
    public Task<CashTransaction> PersistCashTransaction(CashTransaction cashTransaction);
    public Task<CashTransaction> FindCashTransactionById();
    public Task<List<CashTransaction>> FindAllTransactions();
}