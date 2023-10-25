using CashBusiness.Application.Common.Errors.Transaction;
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
    
    public async Task<Result<CashTransaction>> PersistCashTransactionAsync(CashTransaction cashTransaction)
    {
        CashTransaction savedTransaction = await _repository.PersistCashTransactionAsync(cashTransaction);
        return Result.Ok(savedTransaction);
    }

    public async Task<Result<CashTransaction>> UpdateCashTransactionAsync(CashTransaction cashTransaction)
    {
        return Result.Ok( await _repository.UpdateCashTransactionAsync(cashTransaction));
    }

    public async Task<Result<int>> DeleteCashTransactionAsync(Guid id)
    {
        int deletedRows = await _repository.DeleteCashTransactionByIdAsync(id);
        if (deletedRows == 0)
        {
            return Result.Fail(new NotFoundCashTransaction($"There is not exist a cash transaction with id: {id}"));
        }
        
        return Result.Ok(deletedRows);
    }
}