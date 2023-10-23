using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Commands;

public interface ICashTransactionCommandService
{
    public Result<CashTransaction> PersistCashTransaction(string clientId, string voucher, string operationId,
        double amount, string observation);
    
}