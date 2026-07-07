using InventoryManagement.Data.Context;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Implementation;

public class PurchaseRepository(AppDbContext context) : GenericRepository<PurchaseOrder>(context), IPurchaseRepository
{
    public async Task<PurchaseOrder?> GetPurchaseOrderDetailsAsync(Guid Id)
    {
        return await _context.PurchaseOrders.Include(x => x.PurchaseOrderItems).ThenInclude(x=> x.Product).Include(x => x.Supplier).Include(x => x.Warehouse).FirstOrDefaultAsync(x=> x.Id == Id);
    }
}
