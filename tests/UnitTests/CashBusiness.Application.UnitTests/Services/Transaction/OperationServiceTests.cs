using CashBusiness.Application.Common.Persistence;
using CashBusiness.Application.Services.Transaction.Queries;
using CashBusiness.Application.UnitTests.Services.Transaction.ServiceUtils;
using CashBusiness.Domain.Entity;
using CashBusiness.Infraestructure.Persistence;
using CashBusiness.Infraestructure.Persistence.Transaction;
using FluentResults;
using Moq;


namespace CashBusiness.Application.UnitTests.Services.Transaction;
using CashBusiness.Application.Services.Transaction;

public class OperationServiceTests
{
    
    private readonly Mock<IOperationRepository> _mockOperationRepository;  
    private readonly IOperationQueryService _operationService;
      
    
    public OperationServiceTests()
    {
        this._mockOperationRepository = new Mock<IOperationRepository>();
        this._operationService = new OperationQueryService(_mockOperationRepository.Object);
    }
    
    [Fact]
    public async Task GetOperationsAsync_ReturnsOperations()
    {
        Operation operation = new Operation( );
        operation.Id = Guid.NewGuid();
        operation.Name = "Ingreso";

        _mockOperationRepository.Setup(
                x => x.findAll()
                )
            .ReturnsAsync(new List<Operation> {operation});
        
        Result<List<Operation>> result = await _operationService.FindAllOperationsAsync();
        Assert.Single(result.Value);
    }


    [Fact]
    public async Task GetOperationAsync_TwoOperationsInDatabase_shouldReturnTwoRecords()
    {
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
 
        dbContext.Operations.Add(new Operation { Id = Guid.NewGuid(), Name = "Ingresos" });
        dbContext.Operations.Add(new Operation { Id = Guid.NewGuid(), Name = "Egresos" });
        dbContext.SaveChanges();
        
        var repository = new OperationRepositoryImpl(dbContext);
        var service = new OperationQueryService(repository);
        
        Result<List<Operation>> operations = await service.FindAllOperationsAsync();
        
        Assert.NotNull(operations);
        Assert.Equal(2, operations.Value.Count()); 
    }

    [Fact]
    public async Task GetOperationAsync_ExistentOperationInDatabase_shouldReturnOperation()
    {
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        Guid registeredOperationId = Guid.NewGuid();
        string registeredOperationName = "Devoluciones";
        
        dbContext.Operations.Add(new Operation { Id = registeredOperationId, Name = registeredOperationName});
        dbContext.SaveChanges();
        
        var repository = new OperationRepositoryImpl(dbContext);
        var service = new OperationQueryService(repository);
        
        Result<Operation> operationsResult = await service.FindOperationByIdAsync(registeredOperationId.ToString());
       
  
        Assert.Equal(registeredOperationId, operationsResult.Value.Id); 
        Assert.Equal(registeredOperationName, operationsResult.Value.Name);
        
    }
    
    
    [Fact]
    public async Task GetOperationAsync_InExistentOperationInDatabase_shouldReturnResultFail()
    {
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
        Guid nonexistentId = Guid.NewGuid();
        
        var repository = new OperationRepositoryImpl(dbContext);
        var service = new OperationQueryService(repository);
        
        Result<Operation> operationsResult = await service.FindOperationByIdAsync(nonexistentId.ToString());
       
  
        Assert.True(operationsResult.IsFailed); 

        
    }
}