using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Queries;

public interface IOperationQueryService
{
    public Task<Result<Operation>> FindOperationByIdAsync(string id);
    public Task<Result<List<Operation>>> FindAllOperationsAsync();
}