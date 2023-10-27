using CashBusiness.Application.Common.Errors.User;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Commands;

public class CustomerCommandService: ICustomerCommandService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerCommandService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }


    public async Task<Result<Customer>> RegisterCustomer(string name, string phoneNumber)
    {
        Customer customer = await _customerRepository.PersistedCustomer(name, phoneNumber);
        return Result.Ok(customer);
    }
    
}