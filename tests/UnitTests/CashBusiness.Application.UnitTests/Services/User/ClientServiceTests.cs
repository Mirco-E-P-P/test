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

public class ClientServiceTests
{
    
    [Fact]
    public async Task ClientQueryService_GetRegisteredClientById_ShouldReturnClient()
    {
        //
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        IClientRepository clientRepository = new ClientRepositoryImpl(dbContext);
        IClientQueryService clientQueryService = new ClientQueryService(clientRepository);
        
        //
        Guid registeredId = Guid.NewGuid();
        string registeredName = "Juan Perez";
        string registeredPhoneNumber = "60606060";
        
        dbContext.Clients.Add(new Client { Id = registeredId, Name = registeredName, PhoneNumber = registeredPhoneNumber });
        await dbContext.SaveChangesAsync();
        
        //
        Result <Client> resultClient = await clientQueryService.FindClientById(registeredId.ToString());
        
        Assert.Equal(registeredId.ToString(), resultClient.Value.Id.ToString());
        Assert.True(resultClient.IsSuccess);
    }

    [Fact]
    public async Task ClientQueryService_FindNoRegisteredClientById_ShouldNotFoundClientError()
    {
        //
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        IClientRepository clientRepository = new ClientRepositoryImpl(dbContext);
        IClientQueryService clientQueryService = new ClientQueryService(clientRepository);
        
        //
        Guid noRegisteredId = Guid.NewGuid();
        
        //
        Result <Client> resultClient = await clientQueryService.FindClientById(noRegisteredId.ToString());
        
        
        Assert.False(resultClient.IsSuccess);
        Assert.Equal(HttpStatusCode.NotFound, resultClient.Errors[0].Metadata["statusCode"]);

    }


}