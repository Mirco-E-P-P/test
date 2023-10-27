using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence;

public interface ICashTransactionRepository
{
    public Task<CashTransaction> PersistCashTransactionAsync(CashTransaction cashTransaction);
    public Task<CashTransaction> FindCashTransactionByIdAsync(Guid id);
    public Task<List<CashTransaction>> FindAllTransactionsAsync();
    public Task<CashTransaction> UpdateCashTransactionAsync(CashTransaction cashTransaction);
    public Task<int> DeleteCashTransactionByIdAsync(Guid id);
}