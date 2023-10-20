using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.user;

public interface IClientRepository
{
    public Task<Client> PersistedClient(string name, string phoneNumber);
    public Task<Client> FindClientById(string id);
    public Task<List<Client>> FindAllClients();
    public Task<Client> FindClientByName(string name);

}