using FluentResults;

namespace CashBusiness.Application.Services.CustomerServices.Queries;

public interface ICustomerQueryService
{
    public Task<Result<Domain.Entity.Customer>> FindCustomerByIdAsync(Guid id);
    public Task<Result<List<Domain.Entity.Customer>>> FindAllCustomersAsync();
}