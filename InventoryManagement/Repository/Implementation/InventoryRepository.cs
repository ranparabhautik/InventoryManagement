using InventoryManagement.Data.Context;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Implementation;

public class InventoryRepository(AppDbContext context) : GenericRepository<Inventory>(context), IInventoryRepository
{
    public async Task<Inventory?> GetInventoryAsync(Guid productId, Guid warehouseId)
    {
        return await _context.Inventory.Include(x => x.WareHouse).Include(x => x.Product).Where(x => x.ProductId == productId && x.WareHouseId == warehouseId).FirstOrDefaultAsync();
    }
}
