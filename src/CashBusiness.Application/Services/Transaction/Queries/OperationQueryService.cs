using CashBusiness.Application.Common.Errors;
using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.Transaction.Queries;

public class OperationQueryService: IOperationQueryService
{
    private readonly IOperationRepository _operationRepository;
    
    public OperationQueryService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }
    
    public async Task<Result<Operation>> FindOperationByIdAsync(Guid id)
    {
        Operation operation = await _operationRepository.findById(id);
        
        if (operation == null)
        {
            return Result.Fail(new OperationNotFound($"Could not find operation with id:{id}" ));
        }
        
        return Result.Ok(operation);
    }

    public async Task<Result<List<Operation>>> FindAllOperationsAsync()
    {
        return Result.Ok(await _operationRepository.findAll());
    }
}