using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashBusiness.Application.Common.Persistence;
using CashBusiness.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashBusiness.Infraestructure.Persistence;

public class OperationRepositoryImpl :IOperationRepository
{
    private readonly AppDbContext _context;
    
    public OperationRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Operation>> FindAllOperationsAsync()
    {
        return await _context.Operations.ToListAsync();
    }

    public async Task<Operation> FindOperationByIdAsync(Guid id)
    {
        try
        {
          Operation operation = await _context.Operations.Where(operation => operation.Id == id).FirstAsync();
          return operation;
        }
        catch (Exception e)
        {
            return null;
        } 

    }
}