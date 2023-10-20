using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Queries;

public interface IClientQueryService
{
    public Task<Result<Client>> FindClientById(string id);
    public Task<Result<List<Client>>> FindAllClients();
}