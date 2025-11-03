using Core.Persistent.Repository;
using Example.Entity.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Service;

public class ExampleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDbContextFactory _contextFactory;

    public ExampleService(IUnitOfWork unitOfWork, IDbContextFactory contextFactory)
    {
        _unitOfWork = unitOfWork;
        _contextFactory = contextFactory;
    }

   

    
    public async Task<IEnumerable<GoAdmin>> GetAllUserAsync()
    {
        using var primaryDb = _contextFactory.CreateDbContext("Sys");
        
        var orders = await primaryDb.Set<GoAdmin>().ToListAsync();
        return orders;
        
    }

}