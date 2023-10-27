using CashBusiness.Application.Services.CustomerServices.Commands;
using CashBusiness.Application.Services.CustomerServices.Queries;
using CashBusiness.Contracts.Customer.Requests;
using CashBusiness.Contracts.Customer.Responses;
using CashBusiness.Domain.Entity;
using FluentResults;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers;

[ApiController]
[Route("customer")]
public class CustomerController: ControllerBase
{
    private readonly ICustomerCommandService _customerCommandService;
    private readonly ICustomerQueryService _customerQueryService;
    private readonly IMapper _mapper;
    

    public CustomerController(ICustomerQueryService customerQueryService, 
        ICustomerCommandService customerCommandService,
        IMapper mapper)
    {
        _customerQueryService = customerQueryService;
        _customerCommandService = customerCommandService;
        _mapper = mapper;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        Result<Customer> customerResult = await _customerQueryService.FindCustomerByIdAsync(id);
        
        if (customerResult.IsFailed)
        {
            IError firstError = customerResult.Errors[0];
            return Problem(title: firstError.Message, statusCode: (int) firstError.Metadata["statusCode"]);
        }
        
        return Ok(_mapper.Map<CustomerResponse>(customerResult.Value));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomer(CreateCustomerRequest request)
    {
        Result<Customer> customerResult = await _customerCommandService.RegisterCustomerAsync(request.Name, request.PhoneNumber);
        return Ok( _mapper.Map<CustomerResponse>(customerResult.Value) );
    }

    [HttpGet]
    public async Task<IActionResult> FinAllCustomer()
    {
        Result<List<Customer>> customersResult = await _customerQueryService.FindAllCustomersAsync();
        List<CustomerResponse> customerVos = _mapper.Map<List<CustomerResponse>>(customersResult.Value);
        return Ok(customerVos);
    }
    
}