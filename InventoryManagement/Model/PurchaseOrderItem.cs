namespace InventoryManagement.Model;
public class PurchaseOrderItem:BaseEntity
{
    public Guid ProductId {  get; set; }
    public Product Product { get; set; }

    public Guid PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; }
    public int Quantity { get; set; }
    public int UnitPrice { get; set; }
}
