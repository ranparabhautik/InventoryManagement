namespace InventoryManagement.Model;

public class Product : BaseEntity, ISoftDelete
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }

    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public int ProductPrice { get; set; }
    public int MinAlert { get; set; }

    public Guid CategoryId { get; set; }
    public ProductCategories ProductCategories { get; set; } 

    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<PurchaseOrderItem> PurchaseOrdersItems { get; set; } = new List<PurchaseOrderItem>();

    public ICollection<RecordTransaction> RecordTransactions { get; set; } = new List<RecordTransaction>();
}
