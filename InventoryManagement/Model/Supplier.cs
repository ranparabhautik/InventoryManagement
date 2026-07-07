namespace InventoryManagement.Model;
public class Supplier:BaseEntity
{
    public string SupplierName { get; set; }
    public string SupplierPhoneNo { get; set; }
    public string SupplierAddress { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();

    public ICollection<PurchaseOrder> PurchaseOrder { get; set; } = new List<PurchaseOrder>();
}
