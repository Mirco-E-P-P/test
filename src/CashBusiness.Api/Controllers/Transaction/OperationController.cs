using CashBusiness.Application.Services.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.Transaction;

[ApiController]
[Route("operation")]
public class OperationController: ControllerBase
{
    private readonly IOperationService _operationService;
    
    public OperationController(IOperationService operationService)
    {
        _operationService = operationService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _operationService.findAll();
        return Ok(result);
    }
    
    
    
}