namespace InventoryManagement.DTOs;
public class ResponseProductDTO
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public int MinAlert { get; set; }
    public int ProductPrice { get; set; }
    public string CategoryName{ get; set; }
    public string SupplierName { get; set; }
}
