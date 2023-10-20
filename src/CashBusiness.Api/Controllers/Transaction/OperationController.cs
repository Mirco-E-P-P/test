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
    public async Task<IActionResult> findAllOperations()
    {
        Result<List<Operation>> result = await _operationQueryService.FindAllOperationsAsync();
        return Ok(result.Value);
    }
    
    
    
    
}