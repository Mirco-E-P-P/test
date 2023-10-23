using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.Transaction;

public interface ICashTransactionRepository
{
    
    public Task<CashTransaction> PersistCashTransaction(string clientId, string voucher, string operationId, double amount, string observation );
    public Task<CashTransaction> FindCashTransactionById();
    public Task<List<CashTransaction>> FindAllTransactions();
}