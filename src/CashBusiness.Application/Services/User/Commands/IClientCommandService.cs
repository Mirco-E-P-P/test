using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Commands;

public interface IClientCommandService
{
    public Task<Result<Client>> RegisterClient(string name, string phoneNumber);
}