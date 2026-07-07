namespace InventoryManagement.Model;
public class ProductCategories:BaseEntity
{
    public string CategoryName { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
    