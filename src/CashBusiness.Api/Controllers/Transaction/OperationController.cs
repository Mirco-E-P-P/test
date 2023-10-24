
using CashBusiness.Application.Services.Transaction.Queries;
using CashBusiness.Contracts.Transaction.vo;
using CashBusiness.Domain.Entity;
using FluentResults;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.Transaction;

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
        return Ok(_mapper.Map<List<OperationVo>>(result.Value));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FindOperationById(Guid id)
    {
        
        Result<Operation> result = await _operationQueryService.FindOperationByIdAsync(id);
        
        if (result.IsSuccess)
        {
            return Ok(_mapper.Map<OperationVo>(result.Value));
        }
        
        IError firstError = result.Errors[0];

        return Problem(firstError.Message, statusCode: 404 );
    }
    
    
}