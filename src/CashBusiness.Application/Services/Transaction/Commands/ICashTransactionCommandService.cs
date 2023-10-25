using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Commands;

public interface ICashTransactionCommandService
{
    public Task<Result<CashTransaction>> PersistCashTransactionAsync(CashTransaction cashTransaction);

    public Task<Result<CashTransaction>> UpdateCashTransactionAsync(CashTransaction cashTransaction);
    public Task<Result<int>> DeleteCashTransactionAsync(Guid id);
}