namespace InventoryManagement.DTOs;

public class CreatePurchaseOrderDTO
{
    public Guid SupplierId { get; set; }
    public Guid WareHouseId { get; set; }
    public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
}