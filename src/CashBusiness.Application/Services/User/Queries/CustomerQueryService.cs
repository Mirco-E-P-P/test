using CashBusiness.Application.Common.Errors.User;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Queries;

public class CustomerQueryService: ICustomerQueryService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerQueryService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> FindCustomerById(string id)
    {
        Customer customer = await _customerRepository.FindCustomerById(id);

        if (customer == null)
        {
            return Result.Fail(new NotFoundCustomer($"No such customer found for id: {id}" ));
        }
        return Result.Ok(customer);
    }

    public async Task<Result<List<Customer>>> FindAllCustomers()
    {
        return Result.Ok(await _customerRepository.FindAllCustomers());
    }
    
}