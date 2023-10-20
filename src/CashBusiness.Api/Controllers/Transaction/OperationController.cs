using CashBusiness.Application.Services.Transaction;
using CashBusiness.Application.Services.Transaction.Queries;
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
    public async Task<IActionResult> Get()
    {
        var result = await _operationQueryService.FindAllOperationsAsync();
        return Ok(result);
    }
    
    
}