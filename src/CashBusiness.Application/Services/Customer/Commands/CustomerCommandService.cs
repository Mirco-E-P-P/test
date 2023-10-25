using CashBusiness.Application.Common.Persistence.Customer;
using FluentResults;

namespace CashBusiness.Application.Services.Customer.Commands;

public class CustomerCommandService: ICustomerCommandService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerCommandService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }


    public async Task<Result<Domain.Entity.Customer>> RegisterCustomerAsync(string name, string phoneNumber)
    {
        Domain.Entity.Customer customer = await _customerRepository.PersistedCustomerAsync(name, phoneNumber);
        return Result.Ok(customer);
    }
    
}