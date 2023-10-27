using CashBusiness.Application.Common.Errors;
using CashBusiness.Application.Common.Persistence;
using FluentResults;

namespace CashBusiness.Application.Services.CustomerServices.Queries;

public class CustomerQueryService: ICustomerQueryService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerQueryService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Domain.Entity.Customer>> FindCustomerByIdAsync(Guid id)
    {
        Domain.Entity.Customer customer = await _customerRepository.FindCustomerByIdAsync(id);

        if (customer == null)
        {
            return Result.Fail(new CustomerNotFound($"No such customer found for id: {id}" ));
        }
        return Result.Ok(customer);
    }

    public async Task<Result<List<Domain.Entity.Customer>>> FindAllCustomersAsync()
    {
        return Result.Ok(await _customerRepository.FindAllCustomersAsync());
    }
    
}