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


    public async Task<Result<CashTransaction>> GetTransactionByIdAsync(Guid id)
    {
        CashTransaction cashTransaction = await _cashTransactionRepository.FindCashTransactionByIdAsync(id);

        if (cashTransaction == null)
        {
            return Result.Fail(new NotFoundCashTransaction($"Invalid cash transaction id: {id}"));
        }

        return Result.Ok(cashTransaction);
    }

    public async Task<Result<List<CashTransaction>>> GetAllTransactionsAsync()
    {
        return Result.Ok( await _cashTransactionRepository.FindAllTransactionsAsync());
    }
}