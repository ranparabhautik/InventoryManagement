using InventoryManagement.Data.Context;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;

namespace InventoryManagement.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepo { get; }

    public IInventoryRepository InventoryRepo{ get; }

    public IPurchaseRepository PurchaseRepo { get; }

    public IGenericRepository<ProductCategories> CategoryRepo { get; }

    public IGenericRepository<WareHouse> WareHouseRepo { get; }

    public IGenericRepository<Supplier> SupplierRepo { get; }

    public IGenericRepository<PurchaseOrderItem> PurchaseOrderItemRepo { get; }

    public IGenericRepository<RecordTransaction> RecordRepo { get; }

    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        ProductRepo = new ProductRepository(context);
        InventoryRepo = new InventoryRepository(context);
        PurchaseRepo = new PurchaseRepository(context);
        CategoryRepo = new GenericRepository<ProductCategories>(context);
        WareHouseRepo = new GenericRepository<WareHouse>(context);
        SupplierRepo = new GenericRepository<Supplier>(context);
        PurchaseOrderItemRepo = new GenericRepository<PurchaseOrderItem>(context);
        RecordRepo = new GenericRepository<RecordTransaction>(context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAllAsync()
    {
        await _context.SaveChangesAsync();
    }
}
