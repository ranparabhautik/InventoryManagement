using InventoryManagement.Data.Context;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Implementation;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> _dbset = context.Set<T>();
    protected readonly AppDbContext _context = context;
    public async Task CreateAsync(T entity)
    {
         await _dbset.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _dbset.FindAsync(id);
         _dbset.Remove(existing);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbset.ToListAsync();
        //return await _dbset.IgnoreQueryFilters().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var existing = await _dbset.FindAsync(id);
        return existing;
    }

    public  Task UpdateAsync( T entity)
    {
         _dbset.Update(entity);
        return Task.CompletedTask;
    }
}
