using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CashBusiness.Infraestructure.Persistence.User;

public class CustomerRepositoryImpl: IClientRepository
{
    private readonly AppDbContext _context;

    public CustomerRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Customer> PersistedClient(string name, string phoneNumber)
    {
        var client = new Customer
        {
            Name = name,
            PhoneNumber = phoneNumber
        };
        
        EntityEntry<Customer> clientSaved = _context.Customers.Add(client);
        
        await _context.SaveChangesAsync();
        
        return clientSaved.Entity;
    }

    public async Task<Customer> FindClientById(string id)
    {
        try
        {
            Customer customer = await _context.Customers.Where(client => client.Id.ToString() == id).FirstAsync();
            return customer;
            
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public async Task<List<Customer>> FindAllClients()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> FindClientByName(string name)
    {
        try
        {
            Customer customer = await _context.Customers.Where(client => client.Name == name).FirstAsync();
            return customer;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}