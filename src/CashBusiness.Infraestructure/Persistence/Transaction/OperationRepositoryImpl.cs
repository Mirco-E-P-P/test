using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashBusiness.Infraestructure.Persistence.Transaction;

public class OperationRepositoryImpl :IOperationRepository
{
    private readonly AppDbContext _context;
    
    public OperationRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Operation>> findAll()
    {
        return await _context.Operations.ToListAsync();
    }

    public async Task<Operation> findById(string id)
    {
        try
        {
          Operation operation = await _context.Operations.Where(operation => operation.Id.ToString() == id).FirstAsync();
          return operation;
        }
        catch (Exception e)
        {
            return null;
        } 

    }
}