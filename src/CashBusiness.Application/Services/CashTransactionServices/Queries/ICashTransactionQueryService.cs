using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.CashTransactionServices.Queries;

public interface ICashTransactionQueryService
{
    public Task<Result<CashTransaction>> GetTransactionByIdAsync(Guid id);
    public Task<Result<List<CashTransaction>>> GetAllTransactionsAsync();
}