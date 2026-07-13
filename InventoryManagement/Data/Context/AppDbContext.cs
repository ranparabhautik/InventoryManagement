using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

    /// <summary>
    /// For Auditing of changes of entities
    /// </summary>
    public DbSet<AuditEntity> AuditLogs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<AuditEntity> auditlist = new List<AuditEntity>();

        foreach(var entry in ChangeTracker.Entries())
        {

            if(entry.Entity is AuditEntity) { continue; }

            if(entry.State == EntityState.Modified )
            {
                var audit = new AuditEntity
                {
                    Action = "Update",
                    ChangedAt = DateTime.UtcNow,
                    TableName = entry.Entity.GetType().Name,
                    OldValues = JsonSerializer.Serialize(entry.OriginalValues.ToObject()),
                    NewValues = JsonSerializer.Serialize(entry.CurrentValues.ToObject())
                };
                auditlist.Add(audit);
            }else if (entry.State == EntityState.Deleted)
            {
                var audit = new AuditEntity
                {
                    Action = "Delete",
                    ChangedAt = DateTime.UtcNow,
                    TableName = entry.Entity.GetType().Name,
                    OldValues = JsonSerializer.Serialize(entry.OriginalValues.ToObject()),
                    NewValues = null
                };
                auditlist.Add(audit);
            }else if(entry.State == EntityState.Added)
            {
                var audit = new AuditEntity
                {
                    Action = "Added",
                    ChangedAt = DateTime.UtcNow,
                    TableName = entry.Entity.GetType().Name,
                    OldValues = null,
                    NewValues = JsonSerializer.Serialize(entry.CurrentValues.ToObject())
                };
                auditlist.Add(audit);
                
            }
            else
            {
                continue;
            }
        }
        if (auditlist.Any())
        {
            AuditLogs.AddRange(auditlist);
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}