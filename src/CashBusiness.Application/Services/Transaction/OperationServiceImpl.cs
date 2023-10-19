using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Services.Transaction;

public class OperationServiceImpl: IOperationService
{
    
    private readonly IOperationRepository _operationRepository;
    
    public OperationServiceImpl(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }
    
    
    public async Task<List<Operation>> findAll()
    {
        return await _operationRepository.findAll();
    }

    public async Task<Operation> findById(string id)
    {
        return await _operationRepository.findById(id);
    }
}