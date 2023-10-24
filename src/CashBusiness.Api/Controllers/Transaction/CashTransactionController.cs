using CashBusiness.Application.Services.Transaction.Commands;
using CashBusiness.Application.Services.Transaction.Queries;
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
    private readonly IOperationQueryService _operationQueryService;
    private readonly IMapper _mapper;

    public CashTransactionController(
        ICashTransactionCommandService cashTransactionCommandService, 
        ICustomerQueryService customerQueryService, 
        IOperationQueryService operationQueryService,
        IMapper mapper)
    {
        _cashTransactionCommandService = cashTransactionCommandService;
        _customerQueryService = customerQueryService;
        _operationQueryService = operationQueryService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterCashTransaction(RegisterCashTransactionDto dto)
    {
        Result <Customer> customerResult = await _customerQueryService.FindCustomerById(dto.CustomerId);
        
        if (customerResult.IsFailed)
        {
            IError firstCustomerResultErrorError = customerResult.Errors[0];
            return Problem(title: firstCustomerResultErrorError.Message, statusCode:(int) firstCustomerResultErrorError.Metadata["statusCode"]);
        }

        Result<Operation> operationResult = await _operationQueryService.FindOperationByIdAsync(dto.OperationId);

        if (operationResult.IsFailed)
        {
            IError firstOperationResultError = operationResult.Errors[0];
            return Problem(title: firstOperationResultError.Message, statusCode:(int) firstOperationResultError.Metadata["statusCode"]);
        }


        CashTransaction cashTransaction = _mapper.Map<CashTransaction>(dto);
        Result<CashTransaction> transactionResult = await _cashTransactionCommandService.PersistCashTransaction(cashTransaction);
        return Ok(_mapper.Map<CashTransactionVo>(transactionResult.Value));
    }
    
    
    
    
    
}