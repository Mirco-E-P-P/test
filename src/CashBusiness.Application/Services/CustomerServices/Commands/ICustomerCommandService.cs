using FluentResults;

namespace CashBusiness.Application.Services.CustomerServices.Commands;

public interface ICustomerCommandService
{
    public Task<Result<Domain.Entity.Customer>> RegisterCustomerAsync(string name, string phoneNumber);
}