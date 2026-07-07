namespace InventoryManagement.DTOs
{
    public class ItemDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
