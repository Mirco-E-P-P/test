using CashBusiness.Application.Services.Transaction;
using CashBusiness.Application.Services.Transaction.Queries;
using CashBusiness.Domain.Entity;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.Transaction;

[ApiController]
[Route("operation")]
public class OperationController: ControllerBase
{
    private readonly IOperationQueryService _operationQueryService;
    
    public OperationController(IOperationQueryService operationService)
    {
        _operationQueryService = operationService;
    }
    
    [HttpGet]
    public async Task<IActionResult> FindAllOperations()
    {
        Result<List<Operation>> result = await _operationQueryService.FindAllOperationsAsync();
        return Ok(result.Value);
    }
    
    [HttpGet("{id:string}")]
    public async Task<IActionResult> FindOperationById(string id)
    {
        Result<Operation> result = await _operationQueryService.FindOperationByIdAsync(id);

        var firstError = result.Errors[0];
        if (result.IsFailed)
        {
            return Problem(title: firstError.Message, statusCode: 404 );
        }

        return Ok(result.Value);
    }
    
    
}