using CashBusiness.Application.Common.Errors;
using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.CashTransactionServices.Queries;

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
            return Result.Fail(new CashTransactionNotFound($"Invalid cash transaction id: {id}"));
        }

        return Result.Ok(cashTransaction);
    }

    public async Task<Result<List<CashTransaction>>> GetAllTransactionsAsync()
    {
        return Result.Ok( await _cashTransactionRepository.FindAllTransactionsAsync());
    }
}