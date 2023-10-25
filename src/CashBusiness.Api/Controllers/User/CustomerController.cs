using CashBusiness.Application.Services.Customer.Commands;
using CashBusiness.Application.Services.Customer.Queries;
using CashBusiness.Contracts.Customer.dto;
using CashBusiness.Contracts.Customer.vo;
using CashBusiness.Domain.Entity;
using FluentResults;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CashBusiness.Api.Controllers.User;

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
        
        return Ok(_mapper.Map<CustomerVo>(customerResult.Value));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomer(CreateCustomerDto createCustomerDto)
    {
        Result<Customer> customerResult = await _customerCommandService.RegisterCustomerAsync(createCustomerDto.Name, createCustomerDto.PhoneNumber);
        return Ok( _mapper.Map<CustomerVo>(customerResult.Value) );
    }

    [HttpGet]
    public async Task<IActionResult> FinAllCustomer()
    {
        Result<List<Customer>> customersResult = await _customerQueryService.FindAllCustomersAsync();
        List<CustomerVo> customerVos = _mapper.Map<List<CustomerVo>>(customersResult.Value);
        return Ok(customerVos);
    }

    



}