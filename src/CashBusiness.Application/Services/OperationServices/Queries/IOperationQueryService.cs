using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.OperationServices.Queries;

public interface IOperationQueryService
{
    public Task<Result<Operation>> FindOperationByIdAsync(Guid id);
    public Task<Result<List<Operation>>> FindAllOperationsAsync();
}