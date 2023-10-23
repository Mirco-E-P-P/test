using CashBusiness.Domain.Entity;
using FluentResults;

namespace CashBusiness.Application.Services.User.Queries;

public interface IClientQueryService
{
    public Task<Result<Customer>> FindClientById(string id);
    public Task<Result<List<Customer>>> FindAllClients();
}