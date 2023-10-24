using CashBusiness.Application.Services.Transaction.Commands;
using CashBusiness.Application.Services.User.Queries;
using CashBusiness.Contracts.Transaction.dto;
using CashBusiness.Contracts.Transaction.vo;
using CashBusiness.Domain.Entity;
using FluentResults;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.Transaction;

[ApiController]
[Route("transaction")]
public class CashTransactionController: ControllerBase
{
    private readonly ICashTransactionCommandService _cashTransactionCommandService;
    private readonly ICustomerQueryService _customerQueryService;
    private readonly IMapper _mapper;

    public CashTransactionController(
        ICashTransactionCommandService cashTransactionCommandService, 
        ICustomerQueryService customerQueryService, 
        IMapper mapper)
    {
        _cashTransactionCommandService = cashTransactionCommandService;
        _customerQueryService = customerQueryService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(RegisterCashTransactionDto dto)
    {
        Result <Customer> customerResult = await _customerQueryService.FindCustomerById(dto.CustomerId);
        
        if (customerResult.IsFailed)
        {
            IError firstError = customerResult.Errors[0];
            return Problem(title: firstError.Message, statusCode:(int) firstError.Metadata["status"]);
        }
        
        
        CashTransaction cashTransaction = _mapper.Map<CashTransaction>(dto);
        Result<CashTransaction> transactionResult = await _cashTransactionCommandService.PersistCashTransaction(cashTransaction);
        
        
        return Ok(_mapper.Map<CashTransactionVo>(transactionResult.Value));
    }
    
    
    
    
    
}