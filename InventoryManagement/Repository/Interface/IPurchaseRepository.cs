using InventoryManagement.Model;

namespace InventoryManagement.Repository.Interface;

public interface IPurchaseRepository:IGenericRepository<PurchaseOrder>
{
    Task<PurchaseOrder?> GetPurchaseOrderDetailsAsync(Guid Id);
}
