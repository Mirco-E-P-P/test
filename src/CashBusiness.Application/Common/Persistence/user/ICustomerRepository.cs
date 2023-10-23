using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.user;

public interface ICustomerRepository
{
    public Task<Customer> PersistedCustomer(string name, string phoneNumber);
    public Task<Customer> FindCustomerById(string id);
    public Task<List<Customer>> FindAllCustomers();
    public Task<Customer> FindCustomerByName(string name);

}