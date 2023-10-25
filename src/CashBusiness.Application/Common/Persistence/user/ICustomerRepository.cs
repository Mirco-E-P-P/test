using CashBusiness.Domain.Entity;

namespace CashBusiness.Application.Common.Persistence.user;

public interface ICustomerRepository
{
    public Task<Customer> PersistedCustomerAsync(string name, string phoneNumber);
    public Task<Customer> FindCustomerByIdAsync(Guid id);
    public Task<List<Customer>> FindAllCustomersAsync();
    public Task<Customer> FindCustomerByNameAsync(string name);

}