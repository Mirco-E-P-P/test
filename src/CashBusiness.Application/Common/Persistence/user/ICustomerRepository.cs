using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.user;

public interface IClientRepository
{
    public Task<Customer> PersistedClient(string name, string phoneNumber);
    public Task<Customer> FindClientById(string id);
    public Task<List<Customer>> FindAllClients();
    public Task<Customer> FindClientByName(string name);

}