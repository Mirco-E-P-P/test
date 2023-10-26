using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CashBusiness.Infraestructure.Persistence;

public class CustomerRepositoryImpl: ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Customer> PersistedCustomerAsync(string name, string phoneNumber)
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

    public async Task<Customer> FindCustomerByIdAsync(Guid id)
    {
        try
        {
            Customer customer = await Queryable.Where<Customer>(_context.Customers, customer => customer.Id == id).FirstAsync();
            return customer;
            
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public async Task<List<Customer>> FindAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync<Customer>();
    }

    public async Task<Customer> FindCustomerByNameAsync(string name)
    {
        try
        {
            Customer customer = await Queryable.Where<Customer>(_context.Customers, customer => customer.Name == name).FirstAsync();
            return customer;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}