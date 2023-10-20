using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.user;

public interface IClientRepository
{
    public Task<Client> persistedClient(string name, string phoneNumber);
    public Task<Client> findClientById(string id);
    public Task<List<Client>> findAllClients();

}