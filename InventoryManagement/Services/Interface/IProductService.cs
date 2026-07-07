using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Services.Interface;

public interface IProductService
{
    Task<IEnumerable<ResponseProductDTO>> GetAllProducts();
    Task<Product> GetProductDetail(Guid Id);
    Task CreateProduct(CreateProductDTO dto);
    Task UpdateProduct(Guid id,UpdateProductDTO dto);
    Task DeleteProduct(Guid id);

}
