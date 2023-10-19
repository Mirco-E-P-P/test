using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Services.Transaction;

public interface IOperationService
{
    public Task<List<Operation>> findAll();
    public Task<Operation> findById(string id);
}