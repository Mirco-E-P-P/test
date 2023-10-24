using System.Net;
using CashBusiness.Application.Common.Persistence.Transaction;
using CashBusiness.Application.Common.Persistence.user;
using CashBusiness.Application.Services.Transaction.Queries;
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
        
        Guid newTransactionId = new Guid("58C8311B-244E-40D4-92F2-283F01B581A9");
        
        CashTransaction newTransaction = new CashTransaction()
        {
            Id = newTransactionId,
            CustomerId = new Guid("25d65bb9-de48-472e-8feb-c71cb59f40ac"),
            Voucher = "000000001",
            OperationId = new Guid("9C30807B-5188-4348-B89F-69854029913C"),
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
    










}