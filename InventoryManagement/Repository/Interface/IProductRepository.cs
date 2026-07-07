using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Repository.Interface;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetLowStockProduct();
    Task<ResponseProductDTO?> GetProductDetails(Guid id);

}
