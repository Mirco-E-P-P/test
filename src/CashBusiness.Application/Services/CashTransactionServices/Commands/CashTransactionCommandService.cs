using CashBusiness.Application.Common.Errors;
using CashBusiness.Application.Common.Persistence;
using FluentResults;

namespace CashBusiness.Application.Services.CashTransactionServices.Commands;

public class CashTransactionCommandService: ICashTransactionCommandService
{
    private readonly ICashTransactionRepository _repository;

    public CashTransactionCommandService(ICashTransactionRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<Domain.Entity.CashTransaction>> PersistCashTransactionAsync(Domain.Entity.CashTransaction cashTransaction)
    {
        Domain.Entity.CashTransaction savedTransaction = await _repository.PersistCashTransactionAsync(cashTransaction);
        return Result.Ok(savedTransaction);
    }

    public async Task<Result<Domain.Entity.CashTransaction>> UpdateCashTransactionAsync(Domain.Entity.CashTransaction cashTransaction)
    {
        return Result.Ok( await _repository.UpdateCashTransactionAsync(cashTransaction));
    }

    public async Task<Result<int>> DeleteCashTransactionAsync(Guid id)
    {
        int deletedRows = await _repository.DeleteCashTransactionByIdAsync(id);
        if (deletedRows == 0)
        {
            return Result.Fail(new CashTransactionNotFound($"There is not exist a cash transaction with id: {id}"));
        }
        
        return Result.Ok(deletedRows);
    }
}