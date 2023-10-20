using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence;

public interface IOperationRepository
{
    public Task<List<Operation>> findAll();
    public Task<Operation> findById(string id);
    
}