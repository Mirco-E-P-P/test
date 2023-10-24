using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.Transaction;

public interface ICashTransactionRepository
{
    public Task<CashTransaction> PersistCashTransaction(CashTransaction cashTransaction);
    public Task<CashTransaction> FindCashTransactionById(Guid id);
    public Task<List<CashTransaction>> FindAllTransactions();
    public Task<CashTransaction> UpdateCashTransaction(CashTransaction cashTransaction);
    public Task<int> DeleteCashTransactionById(Guid id);
}