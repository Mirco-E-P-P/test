using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;

namespace CashBusiness.Infraestructure.Persistence.User;

public class ClientRepositoryImpl: IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Client> PersistedClient(string name, string phoneNumber)
    {

        
    }

    public Task<Client> FindClientById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Client>> FindAllClients()
    {
        throw new NotImplementedException();
    }

    public Task<Client> FindClientByName(string name)
    {
        throw new NotImplementedException();
    }
}