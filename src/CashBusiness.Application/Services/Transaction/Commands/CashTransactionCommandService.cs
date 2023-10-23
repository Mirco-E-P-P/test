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
    
    public async Task<Result<CashTransaction>> PersistCashTransaction(string clientId, string voucher, string operationId, double amount, string observation)
    {
        CashTransaction savedTransaction = await 
            _repository.PersistCashTransaction(clientId, voucher, operationId, amount, observation);

        return Result.Ok(savedTransaction);
    }
}