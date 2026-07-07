namespace InventoryManagement.Model;

public class Inventory:BaseEntity
{

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid WareHouseId { get; set; }
    public WareHouse WareHouse { get; set; }

    public int Quantity { get; set; }

    public ICollection<RecordTransaction> RecordTransactions { get; set; } = new List<RecordTransaction>();
    

}
