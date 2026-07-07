namespace InventoryManagement.Model;

public class PurchaseOrder:BaseEntity
{
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public DateTime OrderDate { get; set; } 
    public OrderStatus Status { get; set; }

    public Guid WareHouseId { get; set; }
    public WareHouse Warehouse { get; set; }
    public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>(); 
}
