using InventoryManagement.Model;

namespace InventoryManagement.Repository.Interface;

public interface IInventoryRepository:IGenericRepository<Inventory>
{
    Task<Inventory?> GetInventoryAsync(Guid productId, Guid warehouseId);

}
