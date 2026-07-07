using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Interface;

namespace InventoryManagement.Services.Implementation;

public class ProductService(IUnitOfWork uow,IMapper _mapper) : IProductService
{
    public async Task CreateProduct(CreateProductDTO dto)
    {
        var product = _mapper.Map<Product>(dto);
        await uow.ProductRepo.CreateAsync(product);
    }

    public async Task DeleteProduct(Guid id)
    {
        await uow.ProductRepo.DeleteAsync(id);
    }

    public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts()
    {
        var AllProducts = await uow.ProductRepo.GetAllAsync();
        var result = _mapper.Map<IEnumerable<ResponseProductDTO>>(AllProducts);     
        return result;
    }

    public async Task<ResponseProductDTO> GetProductDetail(Guid Id)
    {
        var product = await uow.ProductRepo.GetProductDetails(Id);
        var result = _mapper.Map<ResponseProductDTO>(product);
        return result;
    }

    public Task UpdateProduct(Guid id, UpdateProductDTO dto)
    {
        throw new NotImplementedException();
    }
}
