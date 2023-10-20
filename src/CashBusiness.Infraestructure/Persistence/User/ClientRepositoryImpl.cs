using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        var client = new Client
        {
            Name = name,
            PhoneNumber = phoneNumber
        };
        
        EntityEntry<Client> clientSaved = await _context.Clients.AddAsync(client);
        
        await _context.SaveChangesAsync();
        
        return clientSaved.Entity;
    }

    public async Task<Client> FindClientById(string id)
    {
        throw new NotImplementedException("No implemented method");
    }

    public async Task<List<Client>> FindAllClients()
    {
        throw new NotImplementedException("No implemented method");
    }

    public async Task<Client> FindClientByName(string name)
    {
        throw new NotImplementedException("No implemented method");
    }
}