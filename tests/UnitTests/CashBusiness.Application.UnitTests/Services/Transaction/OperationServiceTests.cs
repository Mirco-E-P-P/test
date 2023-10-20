using CashBusiness.Application.Common.Persistence;
using CashBusiness.Application.UnitTests.Services.Transaction.ServiceUtils;
using CashBusiness.Domain.Entity;
using CashBusiness.Infraestructure.Persistence;
using CashBusiness.Infraestructure.Persistence.Transaction;

using Moq;


namespace CashBusiness.Application.UnitTests.Services.Transaction;
using CashBusiness.Application.Services.Transaction;

public class OperationServiceTests
{
    
    private readonly Mock<IOperationRepository> _mockOperationRepository;  
    private readonly IOperationService _operationService;
      
    
    public OperationServiceTests()
    {
        this._mockOperationRepository = new Mock<IOperationRepository>();
        this._operationService = new OperationServiceImpl(_mockOperationRepository.Object);
    }
    
    [Fact]
    public async Task GetOperationsAsync_ReturnsOperations()
    {
        Operation operation = new Operation( );
        operation.Id = Guid.NewGuid();
        operation.Name = "Ingreso";
        
        
        // Arrange
        
        
        _mockOperationRepository.Setup(
                x => x.findAll()
                )
            .ReturnsAsync(new List<Operation> {operation});

        // Act
        var result = await _operationService.findAll();

        // Assert
        Assert.Single(result);
    }


    [Fact]
    public async Task GetOperationAsync_TwoOperationsInDatabase_shouldReturnTwoRecords()
    {
        AppDbContext dbContext = InMemoryApplicationDatabase.GetInstance().GetApplicationDbContext();
 
        dbContext.Operations.Add(new Operation { Id = Guid.NewGuid(), Name = "Ingresosss" });
        dbContext.Operations.Add(new Operation { Id = Guid.NewGuid(), Name = "Egtrsosadasdas" });
        dbContext.SaveChanges();
        
        var repository = new OperationRepositoryImpl(dbContext);
        var service = new OperationServiceImpl(repository);
        
        var operations = await service.findAll();
        
        Assert.NotNull(operations);
        Assert.Equal(2, operations.Count()); 
    }





}