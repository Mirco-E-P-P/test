using System.Net;
using CashBusiness.Application.Services.CashTransactionServices.Commands;
using CashBusiness.Application.Services.CashTransactionServices.Queries;
using CashBusiness.Application.Services.CustomerServices.Queries;
using CashBusiness.Application.Services.OperationServices.Queries;
using CashBusiness.Contracts.CashTransaction.Requests;
using CashBusiness.Contracts.CashTransaction.Responses;
using CashBusiness.Domain.Entity;
using FluentResults;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers;

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
        Result<List<CashTransaction>> result = await _cashTransactionQueryService.GetAllTransactionsAsync();
        return Ok(_mapper.Map<List<CashTransactionResponse>>(result.Value));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindTransactionById(Guid id)
    {
        Result<CashTransaction> cashTransactionResult = await _cashTransactionQueryService.GetTransactionByIdAsync(id);

        if (cashTransactionResult.IsFailed)
        {
            IError firstError = cashTransactionResult.Errors[0];
            return Problem(title:firstError.Message, statusCode: (int) firstError.Metadata["statusCode"] );
        }

        return Ok(_mapper.Map<CashTransactionResponse>(cashTransactionResult.Value));
    }


    [HttpPost]
    public async Task<IActionResult> RegisterCashTransaction(RegisterCashTransactionRequest request)
    {
        Result <Customer> customerResult = await _customerQueryService.FindCustomerByIdAsync(request.CustomerId);
        
        if (customerResult.IsFailed)
        {
            IError firstCustomerResultErrorError = customerResult.Errors[0];
            return Problem(title: firstCustomerResultErrorError.Message, statusCode:(int) firstCustomerResultErrorError.Metadata["statusCode"]);
        }

        Result<Operation> operationResult = await _operationQueryService.FindOperationByIdAsync(request.OperationId);

        if (operationResult.IsFailed)
        {
            IError firstOperationResultError = operationResult.Errors[0];
            return Problem(title: firstOperationResultError.Message, statusCode:(int) firstOperationResultError.Metadata["statusCode"]);
        }

        Result<CashTransaction> cashTransactionResult = await _cashTransactionQueryService.GetTransactionByIdAsync(request.Id);

        if (cashTransactionResult.IsSuccess)
        {
            return Problem(title: "The transaction id is already in use.", statusCode: (int)HttpStatusCode.Conflict);
        }
        
        CashTransaction cashTransaction = _mapper.Map<CashTransaction>(request);
        Result<CashTransaction> transactionResult = await _cashTransactionCommandService.PersistCashTransactionAsync(cashTransaction);
        return Ok(_mapper.Map<CashTransactionResponse>(transactionResult.Value));
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCashTransaction(UpdateCashTransactionRequest request)
    {
        Result <Customer> findCustomerResult = await _customerQueryService.FindCustomerByIdAsync(request.CustomerId);
        
        if (findCustomerResult.IsFailed)
        {
            IError firstCustomerResultErrorError = findCustomerResult.Errors[0];
            return Problem(title: firstCustomerResultErrorError.Message, statusCode:(int) firstCustomerResultErrorError.Metadata["statusCode"]);
        }
        
        Result<Operation> findOperationResult = await _operationQueryService.FindOperationByIdAsync(request.OperationId);
        
        if (findOperationResult.IsFailed)
        {
            IError firstOperationResultError = findOperationResult.Errors[0];
            return Problem(title: firstOperationResultError.Message, statusCode:(int) firstOperationResultError.Metadata["statusCode"]);
        }

        //ToDo: search AsNoTracking Alternative

        Result<CashTransaction> findCashTransactionResult = await _cashTransactionQueryService.GetTransactionByIdAsync(request.Id);
        
        if (findCashTransactionResult.IsFailed)
        {
            IError firstError = findCashTransactionResult.Errors[0];
            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        CashTransaction cashTransactionUpdated = _mapper.Map<CashTransaction>(request);
        
        Result<CashTransaction> transactionResult = await _cashTransactionCommandService.UpdateCashTransactionAsync(cashTransactionUpdated);
        return Ok(_mapper.Map<CashTransactionResponse>(transactionResult.Value));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCashTransaction(Guid id)
    {
        Result<CashTransaction> findCashTransactionResult =
            await _cashTransactionQueryService.GetTransactionByIdAsync(id);

        if (findCashTransactionResult.IsFailed)
        {
            IError firstError = findCashTransactionResult.Errors[0];
            return Problem(title: firstError.Message, statusCode: (int)firstError.Metadata["statusCode"]);
        }

        Result<int> deleteCashTransactionResult = await _cashTransactionCommandService.DeleteCashTransactionAsync(id);
        return Ok(new SuccessfulEliminationResponse(){
            Message = $" {deleteCashTransactionResult.Value} rows removed successfully "
        }
        );
}
    


}