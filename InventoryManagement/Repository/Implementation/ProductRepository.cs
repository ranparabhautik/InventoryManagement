using InventoryManagement.Data.Context;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Implementation;

public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> GetLowStockProduct()
    {
        return await _context.Products.Where(x => x.ProductStock < x.MinAlert).ToListAsync();
    }

    public async Task<Product?> GetProductDetails(Guid id)
    {
        return await _context.Products.Include(x => x.Inventories).Include(x => x.Supplier).Include(x => x.ProductCategories).FirstOrDefaultAsync(x=> x.Id == id);
    }
}
