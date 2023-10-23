using CashBusiness.Application.Common.Errors.User;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Queries;

public class ClientQueryService: IClientQueryService
{
    private readonly ICustomerRepository _customerRepository;

    public ClientQueryService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Customer>> FindClientById(string id)
    {
        Customer customer = await _customerRepository.FindClientById(id);

        if (customer == null)
        {
            return Result.Fail(new NotFoundClient($"No such client found for id: {id}" ));
        }
        return Result.Ok(customer);
    }

    public async Task<Result<List<Customer>>> FindAllClients()
    {
        return Result.Ok(await _customerRepository.FindAllClients());
    }
    
}