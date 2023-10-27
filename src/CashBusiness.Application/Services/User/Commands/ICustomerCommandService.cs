using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Commands;

public interface ICustomerCommandService
{
    public Task<Result<Customer>> RegisterCustomer(string name, string phoneNumber);
}