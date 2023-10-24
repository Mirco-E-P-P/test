using CashBusiness.Application.Common.Errors.Transaction;
using CashBusiness.Application.Common.Persistence.Transaction;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Queries;

public class CashTransactionQueryService: ICashTransactionQueryService
{
    private readonly ICashTransactionRepository _cashTransactionRepository;

    public CashTransactionQueryService(ICashTransactionRepository cashTransactionRepository)
    {
        _cashTransactionRepository = cashTransactionRepository;
    }


    public async Task<Result<CashTransaction>> GetTransactionById(Guid id)
    {
        CashTransaction cashTransaction = await _cashTransactionRepository.FindCashTransactionById(id);

        if (cashTransaction == null)
        {
            return Result.Fail(new NotFoundCashTransaction($"Invalid cash transaction id: {id}"));
        }

        return Result.Ok(cashTransaction);
    }

    public async Task<Result<List<CashTransaction>>> GetAllTransactions()
    {
        return Result.Ok( await _cashTransactionRepository.FindAllTransactions());
    }
}