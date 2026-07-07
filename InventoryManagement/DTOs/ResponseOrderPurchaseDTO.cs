using InventoryManagement.Model;

namespace InventoryManagement.DTOs;

public class ResponseOrderPurchaseDTO
{
    public Guid Id { get; set; }
    public string SupplierName { get; set; }
    public string WareHouseName { get; set; }
    public OrderStatus Status { get; set; }
    public int TotalAmt { get; set; }

    public List<ItemDTO> Items { get; set; } = new(); 
}
