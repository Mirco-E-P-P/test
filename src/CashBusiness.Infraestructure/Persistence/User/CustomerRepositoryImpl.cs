using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CashBusiness.Infraestructure.Persistence.User;

public class CustomerRepositoryImpl: ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Customer> PersistedCustomer(string name, string phoneNumber)
    {
        var customer = new Customer
        {
            Name = name,
            PhoneNumber = phoneNumber
        };
        
        EntityEntry<Customer> customerSaved = _context.Customers.Add(customer);
        
        await _context.SaveChangesAsync();
        
        return customerSaved.Entity;
    }

    public async Task<Customer> FindCustomerById(string id)
    {
        try
        {
            Customer customer = await _context.Customers.Where(customer => customer.Id.ToString() == id).FirstAsync();
            return customer;
            
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public async Task<List<Customer>> FindAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> FindCustomerByName(string name)
    {
        try
        {
            Customer customer = await _context.Customers.Where(customer => customer.Name == name).FirstAsync();
            return customer;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}