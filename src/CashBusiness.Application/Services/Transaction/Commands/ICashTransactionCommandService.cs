using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Commands;

public interface ICashTransactionCommandService
{
    public Task<Result<CashTransaction>> PersistCashTransaction(CashTransaction cashTransaction);

    public Task<Result<CashTransaction>> UpdateCashTransaction(CashTransaction cashTransaction);
}