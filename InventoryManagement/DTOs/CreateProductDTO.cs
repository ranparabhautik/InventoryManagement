namespace InventoryManagement.DTOs;

public class CreateProductDTO
{
    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public int MinAlert { get; set; }
    public int ProductPrice { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SupplierId { get; set; }
}
