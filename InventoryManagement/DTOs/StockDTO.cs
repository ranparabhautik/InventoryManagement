namespace InventoryManagement.DTOs;

public class StockDTO
{
    public Guid ProductId { get; set; }
    public Guid WareHouseId { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}
