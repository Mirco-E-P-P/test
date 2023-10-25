using System.Net;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Application.Services.User.Commands;
using CashBusiness.Application.Services.User.Queries;
using CashBusiness.Application.UnitTests.Services.Transaction.ServiceUtils;
using CashBusiness.Domain.Entity;
using CashBusiness.Infraestructure.Persistence;
using CashBusiness.Infraestructure.Persistence.User;
using FluentResults;

namespace CashBusiness.Application.UnitTests.Services.User;

public class CustomerServiceTests
{
    
    [Fact]
    public async Task CustomerQueryService_GetRegisteredCustomerById_ShouldReturnCustomer()
    {
        //
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICustomerRepository customerRepository = new CustomerRepositoryImpl(dbContext);
        ICustomerQueryService customerQueryService = new CustomerQueryService(customerRepository);
        
        //
        Guid registeredId = Guid.NewGuid();
        string registeredName = "Juan Perez";
        string registeredPhoneNumber = "60606060";
        
        dbContext.Customers.Add(new Customer { Id = registeredId, Name = registeredName, PhoneNumber = registeredPhoneNumber });
        await dbContext.SaveChangesAsync();
        
        //
        Result <Customer> resultCustomer = await customerQueryService.FindCustomerByIdAsync(registeredId);
        
        Assert.Equal(registeredId.ToString(), resultCustomer.Value.Id.ToString());
        Assert.True(resultCustomer.IsSuccess);
    }

    [Fact]
    public async Task CustomerQueryService_FindNoRegisteredCustomerById_ShouldNotFoundCustomerError()
    {
        //
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICustomerRepository customerRepository = new CustomerRepositoryImpl(dbContext);
        ICustomerQueryService customerQueryService = new CustomerQueryService(customerRepository);
        
        //
        Guid noRegisteredId = Guid.NewGuid();
        
        //
        Result <Customer> resultCustomer = await customerQueryService.FindCustomerByIdAsync(noRegisteredId);
        
        
        Assert.False(resultCustomer.IsSuccess);
        Assert.Equal(HttpStatusCode.NotFound, resultCustomer.Errors[0].Metadata["statusCode"]);

    }
    
    [Fact]
    public async Task CustomerCommandService_RegisterCustomerWithNameAndUserName_ShouldReturnRegisteredCustomer()
    {
        // Act
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICustomerRepository customerRepository = new CustomerRepositoryImpl(dbContext);
        ICustomerCommandService customerCommandService = new CustomerCommandService(customerRepository);
        
        // Arrange
        string newCustomerName = "Maria Delgado";
        string NewCustomerPhoneNumber = "60505050";
        Result <Customer> resultCustomer = await customerCommandService.RegisterCustomerAsync(newCustomerName, NewCustomerPhoneNumber);
        
        // Assert
        Assert.True(resultCustomer.IsSuccess);
        Assert.Equal(newCustomerName, resultCustomer.Value.Name);
        Assert.Equal(NewCustomerPhoneNumber, resultCustomer.Value.PhoneNumber);
    }
    
}