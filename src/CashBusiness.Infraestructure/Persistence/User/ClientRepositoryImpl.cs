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
        try
        {
            Client client = await _context.Clients.Where(client => client.Id.ToString() == id).FirstAsync();
            return client;
            
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public async Task<List<Client>> FindAllClients()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> FindClientByName(string name)
    {
        try
        {
            Client client = await _context.Clients.Where(client => client.Name == name).FirstAsync();
            return client;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}