namespace InventoryManagement.Model;
public class WareHouse:BaseEntity
{
    public string WareHouseLocation { get; set; }
    public string WareHouseName { get; set; }
    
    public ICollection<Inventory> Inventories{ get; set; }
    public ICollection<RecordTransaction> RecordTransactions { get; set; } = new List<RecordTransaction>();
}
