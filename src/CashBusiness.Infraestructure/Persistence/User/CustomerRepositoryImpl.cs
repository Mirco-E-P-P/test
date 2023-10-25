using CashBusiness.Application.Common.Persistence.Customer;
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


    public async Task<Domain.Entity.Customer> PersistedCustomerAsync(string name, string phoneNumber)
    {
        var customer = new Domain.Entity.Customer
        {
            Name = name,
            PhoneNumber = phoneNumber
        };
        
        EntityEntry<Customer> customerSaved = _context.Customers.Add(customer);
        
        await _context.SaveChangesAsync();
        
        return customerSaved.Entity;
    }

    public async Task<Domain.Entity.Customer> FindCustomerByIdAsync(Guid id)
    {
        try
        {
            Domain.Entity.Customer customer = await Queryable.Where<Domain.Entity.Customer>(_context.Customers, customer => customer.Id == id).FirstAsync();
            return customer;
            
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public async Task<List<Domain.Entity.Customer>> FindAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync<Domain.Entity.Customer>();
    }

    public async Task<Domain.Entity.Customer> FindCustomerByNameAsync(string name)
    {
        try
        {
            Domain.Entity.Customer customer = await Queryable.Where<Domain.Entity.Customer>(_context.Customers, customer => customer.Name == name).FirstAsync();
            return customer;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}