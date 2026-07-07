using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data.Context;


public class AppDbContext(DbContextOptions<AppDbContext> option):DbContext(option)
{
   public DbSet<Product> Products { get; set; }
   public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<ProductCategories> ProductCategories { get; set; }
    public DbSet<WareHouse> WareHouses { get; set; }
    public DbSet<Inventory> Inventory { get; set; } 
    public DbSet<RecordTransaction> RecordTransactions { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}