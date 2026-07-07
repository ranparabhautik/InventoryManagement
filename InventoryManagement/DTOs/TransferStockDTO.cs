namespace InventoryManagement.DTOs;

public class TransferStockDTO
{
    public Guid ProductId { get; set; }
    public Guid FromWareHouseId { get; set; }
    public Guid ToWarehouseId { get; set; }
    public int Quantity { get; set; }

    public string Description { get; set; }
}
