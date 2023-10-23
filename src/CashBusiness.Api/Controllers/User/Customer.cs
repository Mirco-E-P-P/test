using CashBusiness.Application.Services.User.Commands;
using CashBusiness.Application.Services.User.Queries;
using CashBusiness.Contracts.User;
using CashBusiness.Domain.Entity;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.User;

[ApiController]
[Route("client")]
public class Customer: ControllerBase
{
    private readonly ICustomerCommandService _customerCommandService;
    private readonly ICustomerQueryService _customerQueryService;

    public Customer(ICustomerQueryService customerQueryService, ICustomerCommandService customerCommandService)
    {
        _customerQueryService = customerQueryService;
        _customerCommandService = customerCommandService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(string id)
    {
        Result<Domain.Entity.Customer> customerResult = await _customerQueryService.FindCustomerById(id);
        
        if (customerResult.IsFailed)
        {
            IError firstError = customerResult.Errors[0];

            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        return Ok(customerResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomer(CreateCustomerDto createCustomerDto)
    {
        Result<Domain.Entity.Customer> customerResult = await _customerCommandService.RegisterCustomer(createCustomerDto.Name, createCustomerDto.PhoneNumber);
        return Ok( customerResult.Value );
    }




}