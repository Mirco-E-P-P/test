using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Queries;

public class CashTransactionQueryService: ICashTransactionQueryService
{
    public Task<Result<CashTransaction>> GetTransactionById()
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<CashTransaction>>> GetAllTransactions()
    {
        throw new NotImplementedException();
    }
}