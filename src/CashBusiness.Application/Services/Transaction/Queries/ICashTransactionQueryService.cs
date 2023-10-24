using FluentResults;
using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Services.Transaction.Queries;

public interface ICashTransactionQueryService
{
    public Task<Result<CashTransaction>> GetTransactionById(Guid id);
    public Task<Result<List<CashTransaction>>> GetAllTransactions();
}