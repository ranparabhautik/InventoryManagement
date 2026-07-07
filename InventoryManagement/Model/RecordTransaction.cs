namespace InventoryManagement.Model;

public class RecordTransaction:BaseEntity
{
   public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid WareHouseId { get; set; }
    public WareHouse WareHouse { get; set; }

    public TransactionType Type{ get; set; }

    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public string? Description { get; set; }
}
