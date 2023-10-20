using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Services.Transaction.Queries;

public class OperationQueryService: IOperationQueryService
{
    private readonly IOperationRepository _operationRepository;
    
    public OperationQueryService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }
    
    public async Task<Operation> FindOperationByIdAsync(string id)
    {
        return await _operationRepository.findById(id);
    }

    public async Task<List<Operation>> FindAllOperationsAsync()
    {
        return await _operationRepository.findAll();
    }
}