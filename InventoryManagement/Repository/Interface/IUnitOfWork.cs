using InventoryManagement.Model;

namespace InventoryManagement.Repository.Interface;

public interface IUnitOfWork:IDisposable
{
    IProductRepository ProductRepo { get; }
    IInventoryRepository InventoryRepo { get; }
    IPurchaseRepository PurchaseRepo { get; }
    IGenericRepository<ProductCategories> CategoryRepo { get; }
    IGenericRepository<WareHouse> WareHouseRepo { get; }
    IGenericRepository<Supplier> SupplierRepo { get; }
    IGenericRepository<PurchaseOrderItem> PurchaseOrderItemRepo { get; }
    IGenericRepository<RecordTransaction> RecordRepo { get; }
    Task SaveChangesAllAsync();
}
