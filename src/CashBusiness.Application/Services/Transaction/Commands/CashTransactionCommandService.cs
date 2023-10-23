using CashBusiness.Application.Common.Persistence.Transaction;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Commands;

public class CashTransactionCommandService: ICashTransactionCommandService
{
    private readonly ICashTransactionRepository _repository;

    public CashTransactionCommandService(ICashTransactionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<CashTransaction>> PersistCashTransaction(CashTransaction cashTransaction)
    {
        CashTransaction savedTransaction = await _repository.PersistCashTransaction(cashTransaction);
        return Result.Ok(savedTransaction);
    }
}