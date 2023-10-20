using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Services.Transaction.Queries;

public interface IOperationQueryService
{
    public Task<Operation> FindOperationByIdAsync(string id);
    public Task<List<Operation>> FindAllOperationsAsync();
}