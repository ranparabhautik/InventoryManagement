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
        await uow.SaveChangesAllAsync();
    }

    public async Task DeleteProduct(Guid id)
    {
        var existing = await uow.ProductRepo.GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception("Product not found");
        }
        if(existing is ISoftDelete softdel)
        {
            existing.IsDeleted = true;
            await uow.ProductRepo.UpdateAsync(existing);
        }
        else
        {
            await uow.ProductRepo.DeleteAsync(id);
        }
        
        await uow.SaveChangesAllAsync();
    }

    public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts()
    {
        var AllProducts = await uow.ProductRepo.GetAllProductsAsync();
        var result = _mapper.Map<IEnumerable<ResponseProductDTO>>(AllProducts);     
        return result;
    }

    public async Task<ResponseProductDTO> GetProductDetail(Guid Id)
    {
        var product = await uow.ProductRepo.GetProductDetails(Id);
        var result = _mapper.Map<ResponseProductDTO>(product);
        return result;
    } 

    public async Task UpdateProduct(Guid id, UpdateProductDTO dto)
    {
        var product = await uow.ProductRepo.GetByIdAsync(id);
        if(product == null)
        {
            throw new Exception("Product not found");
        }
        var result = _mapper.Map(dto, product);
        await uow.ProductRepo.UpdateAsync(result);
        await uow.SaveChangesAllAsync();
    }

    
}
