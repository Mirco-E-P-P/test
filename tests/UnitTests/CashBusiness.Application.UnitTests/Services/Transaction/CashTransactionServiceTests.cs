using System.Net;
using CashBusiness.Application.Common.Persistence;
using CashBusiness.Application.Common.Persistence.Transaction;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Application.Services.Transaction.Commands;
using CashBusiness.Application.Services.Transaction.Queries;
using CashBusiness.Application.Services.User.Commands;
using CashBusiness.Application.Services.User.Queries;
using CashBusiness.Application.UnitTests.Services.Transaction.ServiceUtils;
using CashBusiness.Domain.Entity;
using CashBusiness.Infraestructure.Persistence;
using CashBusiness.Infraestructure.Persistence.Transaction;
using CashBusiness.Infraestructure.Persistence.User;
using FluentResults;

namespace CashBusiness.Application.UnitTests.Services.Transaction;

public class CashTransactionServiceTests
{
    [Fact]
    public async Task CashTransactionQueryService_GetRegisteredTransactionById_ShouldReturnTransaction()
    {
        // Arrange
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICashTransactionRepository cashTransactionRepository = new CashTransactionRepositoryImpl(dbContext);
        ICashTransactionQueryService cashTransactionQueryService = new CashTransactionQueryService(cashTransactionRepository);
        
        
        Guid newOperationGuid = Guid.NewGuid();
        Guid newCustomerGuid = Guid.NewGuid();
        
        Operation newOperation = new Operation
        {
            Id = newOperationGuid,
            Name = "Test Operation",
        };

        Customer newCustomer = new Customer
        {
            Id = newCustomerGuid,
            Name = "Test Customer",
            PhoneNumber = "+591 65656565"
        };

        dbContext.Customers.Add(newCustomer);
        dbContext.Operations.Add(newOperation);
        await dbContext.SaveChangesAsync();
        
        
        Guid newTransactionId = new Guid("58C8311B-244E-40D4-92F2-283F01B581A9");
        
        CashTransaction newTransaction = new CashTransaction()
        {
            Id = newTransactionId,
            CustomerId = newCustomerGuid,
            Voucher = "000000001",
            OperationId = newOperationGuid,
            Amount = 999.15,
            Observation = "None"
        };
        
        dbContext.CashTransactions.Add(newTransaction);
        await dbContext.SaveChangesAsync();
        
        // Act
        Result <CashTransaction> result = await cashTransactionQueryService.GetTransactionById(newTransactionId);
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(newTransactionId, result.Value.Id);
    }
    
    [Fact]
    public async Task CashTransactionQueryService_GetNoRegisteredTransactionById_ShouldReturnNotFoundError()
    {
        // Arrange
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICashTransactionRepository cashTransactionRepository = new CashTransactionRepositoryImpl(dbContext);
        ICashTransactionQueryService cashTransactionQueryService = new CashTransactionQueryService(cashTransactionRepository);
        
        Guid noRegisteredTransactionId = new Guid("58C8311B-244E-40D4-92F2-283F01B581A9");

        
        // Act
        Result <CashTransaction> result = await cashTransactionQueryService.GetTransactionById(noRegisteredTransactionId);
        
        // Assert
        Assert.True(result.IsFailed);
        Assert.Equal(result.Errors[0].Metadata["statusCode"], HttpStatusCode.NotFound);
    }
    

    [Fact]
    public async Task CashTransactionCommandService_PersistTransactionSuccessfully_ShouldReturnRegisterTransaction()
    {
        // Arrange
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICashTransactionRepository cashTransactionRepository = new CashTransactionRepositoryImpl(dbContext);
        ICashTransactionCommandService cashTransactionCommandService = new CashTransactionCommandService(cashTransactionRepository);
        

        Guid newOperationGuid = Guid.NewGuid();
        Guid newCustomerGuid = Guid.NewGuid();
        
        Operation newOperation = new Operation
        {
            Id = newOperationGuid,
            Name = "Test Operation",
        };

        Customer newCustomer = new Customer
        {
            Id = newCustomerGuid,
            Name = "Test Customer",
            PhoneNumber = "+591 65656565"
        };

        dbContext.Customers.Add(newCustomer);
        dbContext.Operations.Add(newOperation);
        await dbContext.SaveChangesAsync();
        
        
        Guid newTransactionId = new Guid("58C8311B-244E-40D4-92F2-283F01B581A9");
        
        CashTransaction newCashTransaction = new CashTransaction()
        {
            Id = newTransactionId,
            CustomerId = newCustomerGuid,
            Voucher = "000000001",
            OperationId = newOperationGuid,
            Amount = 999.15,
            Observation = "None"
        };
        
        // Act
        Result <CashTransaction> result = await cashTransactionCommandService.PersistCashTransaction(newCashTransaction);
        
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(newCashTransaction.Id, result.Value.Id);
        Assert.Equal(newCashTransaction.CustomerId, result.Value.CustomerId);
        Assert.Equal(newCashTransaction.OperationId, result.Value.OperationId);
        Assert.Equal(newCashTransaction.Amount, result.Value.Amount);
        Assert.Equal(newCashTransaction.Voucher, result.Value.Voucher);
    }

    
    [Fact]
    public async Task CashTransactionCommandService_PersistTransactionWithNoRegisteredCustomer_ShouldReturnNotFoundCustomerError()
    {
        // Arrange
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        ICashTransactionRepository cashTransactionRepository = new CashTransactionRepositoryImpl(dbContext);
        ICashTransactionCommandService cashTransactionCommandService = new CashTransactionCommandService(cashTransactionRepository);
        
        
        Guid noRegisteredCustomerGuid = Guid.NewGuid();
        
        Guid newOperationGuid = Guid.NewGuid();
        Operation newOperation = new Operation
        {
            Id = newOperationGuid,
            Name = "Test Operation",
        };
        
        dbContext.Operations.Add(newOperation);
        await dbContext.SaveChangesAsync();
        
        Guid newTransactionId = new Guid("58C8311B-244E-40D4-92F2-283F01B581A9");
        CashTransaction newCashTransaction = new CashTransaction()
        {
            Id = newTransactionId,
            CustomerId = noRegisteredCustomerGuid,
            Voucher = "000000001",
            OperationId = newOperationGuid,
            Amount = 999.15,
            Observation = "None"
        };
        
        // Act
        Result <CashTransaction> result = await cashTransactionCommandService.PersistCashTransaction(newCashTransaction);
        
        
        // Assert
        Assert.True(result.IsSuccess);

    }
    
    
    
}