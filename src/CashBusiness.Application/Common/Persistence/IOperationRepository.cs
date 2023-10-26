using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence;

public interface IOperationRepository
{
    public Task<List<Operation>> FindAllOperationsAsync();
    public Task<Operation> FindOperationByIdAsync(Guid id);
    
}