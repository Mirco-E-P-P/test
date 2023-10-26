using CashBusiness.Application.Services.OperationServices.Queries;
using CashBusiness.Contracts.Operation.Responses;
using CashBusiness.Domain.Entity;
using FluentResults;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers;

[ApiController]
[Route("operation")]
public class OperationController: ControllerBase
{
    private readonly IOperationQueryService _operationQueryService;
    private readonly IMapper _mapper;
    
    public OperationController(IOperationQueryService operationService, IMapper mapper)
    {
        _operationQueryService = operationService;
        this._mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> FindAllOperations()
    {
        Result<List<Operation>> result = await _operationQueryService.FindAllOperationsAsync();
        return Ok(_mapper.Map<List<OperationResponse>>(result.Value));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FindOperationById(Guid id)
    {
        
        Result<Operation> operationResult = await _operationQueryService.FindOperationByIdAsync(id);
        
        if (operationResult.IsFailed)
        {
            IError firstError = operationResult.Errors[0];
            Console.WriteLine(firstError.Message);
            Console.WriteLine(firstError.Metadata["statusCode"]);
            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        return Ok(_mapper.Map<OperationResponse>(operationResult.Value));

    }
    
    
}