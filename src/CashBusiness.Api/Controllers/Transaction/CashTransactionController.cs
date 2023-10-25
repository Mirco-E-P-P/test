using System.Net;
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
    private readonly ICashTransactionQueryService _cashTransactionQueryService;
    private readonly ICustomerQueryService _customerQueryService;
    private readonly IOperationQueryService _operationQueryService;
    private readonly IMapper _mapper;

    public CashTransactionController(
        ICashTransactionCommandService cashTransactionCommandService, 
        ICashTransactionQueryService cashTransactionQueryService,
        ICustomerQueryService customerQueryService, 
        IOperationQueryService operationQueryService,
        IMapper mapper)
    {
        _cashTransactionCommandService = cashTransactionCommandService;
        _cashTransactionQueryService = cashTransactionQueryService;
        _customerQueryService = customerQueryService;
        _operationQueryService = operationQueryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> FindAllCashTransactions()
    {
        Result<List<CashTransaction>> result = await _cashTransactionQueryService.GetAllTransactions();
        return Ok(_mapper.Map<List<CashTransactionVo>>(result.Value));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindTransactionById(Guid id)
    {
        Result<CashTransaction> cashTransactionResult = await _cashTransactionQueryService.GetTransactionById(id);

        if (cashTransactionResult.IsFailed)
        {
            IError firstError = cashTransactionResult.Errors[0];
            return Problem(title:firstError.Message, statusCode: (int) firstError.Metadata["statusCode"] );
        }

        return Ok(_mapper.Map<CashTransactionVo>(cashTransactionResult.Value));
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

        Result<CashTransaction> cashTransactionResult = await _cashTransactionQueryService.GetTransactionById(dto.Id);

        if (cashTransactionResult.IsSuccess)
        {
            return Problem(title: "The transaction id is already in use.", statusCode: (int)HttpStatusCode.Conflict);
        }
        
        CashTransaction cashTransaction = _mapper.Map<CashTransaction>(dto);
        Result<CashTransaction> transactionResult = await _cashTransactionCommandService.PersistCashTransaction(cashTransaction);
        return Ok(_mapper.Map<CashTransactionVo>(transactionResult.Value));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCashTransaction(UpdateCashTransactionDto dto)
    {
        Result <Customer> findCustomerResult = await _customerQueryService.FindCustomerById(dto.CustomerId);
        
        if (findCustomerResult.IsFailed)
        {
            IError firstCustomerResultErrorError = findCustomerResult.Errors[0];
            return Problem(title: firstCustomerResultErrorError.Message, statusCode:(int) firstCustomerResultErrorError.Metadata["statusCode"]);
        }
        
        Result<Operation> findOperationResult = await _operationQueryService.FindOperationByIdAsync(dto.OperationId);
        
        if (findOperationResult.IsFailed)
        {
            IError firstOperationResultError = findOperationResult.Errors[0];
            return Problem(title: firstOperationResultError.Message, statusCode:(int) firstOperationResultError.Metadata["statusCode"]);
        }

        //ToDo: search AsNoTracking Alternative

        Result<CashTransaction> findCashTransactionResult = await _cashTransactionQueryService.GetTransactionById(dto.Id);
        
        if (findCashTransactionResult.IsFailed)
        {
            IError firstError = findCashTransactionResult.Errors[0];
            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        CashTransaction cashTransactionUpdated = _mapper.Map<CashTransaction>(dto);
        
        Result<CashTransaction> transactionResult = await _cashTransactionCommandService.UpdateCashTransaction(cashTransactionUpdated);
        return Ok(_mapper.Map<CashTransactionVo>(transactionResult.Value));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCashTransaction(Guid id)
    {
        Result<CashTransaction> findCashTransactionResult = await _cashTransactionQueryService.GetTransactionById(id);

        if (findCashTransactionResult.IsFailed)
        {
            IError firstError = findCashTransactionResult.Errors[0];
            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        Result<int> deleteCashTransactionResult = await _cashTransactionCommandService.DeleteCashTransaction(id);
        return Ok($" {deleteCashTransactionResult.Value} rows removed successfully ");    
    }
    


}