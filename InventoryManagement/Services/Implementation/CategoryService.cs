using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.Interface;

namespace InventoryManagement.Services.Implementation;

public class CategoryService (IUnitOfWork uow,IMapper mapper): ICategoryService
{

    public async Task CreateCategory(CreateCategoryDTO dto)
    {
        var category = mapper.Map<ProductCategories>(dto);
        await uow.CategoryRepo.CreateAsync(category);
        await uow.SaveChangesAllAsync();
    }

    public async Task DeleteCategory(Guid Id)
    {
        var result = await uow.CategoryRepo.GetByIdAsync(Id);
        if (result == null)
        {
            throw new Exception("Category Not Found");
        }
        await uow.CategoryRepo.DeleteAsync(Id);
        await uow.SaveChangesAllAsync();

    }

    public async Task<IEnumerable<ResponseCategoryDTO>> GetAllCategory()
    {
        var result = await uow.CategoryRepo.GetAllAsync();
        return mapper.Map<IEnumerable< ResponseCategoryDTO>>(result);
    }

    public async Task<ResponseCategoryDTO?> GetCategoryById(Guid Id)
    {
        var result = await uow.CategoryRepo.GetByIdAsync(Id);
        return mapper.Map<ResponseCategoryDTO>(result);
    }

    public async Task UpdateCategory(Guid Id,UpdateCategoriesDTO dto)
    {
        var result = await uow.CategoryRepo.GetByIdAsync(Id);
        if(result == null)
        {
            throw new Exception("Category Not Found");
        }
        var product = mapper.Map(dto, result);
        await uow.CategoryRepo.UpdateAsync(product);
        await uow.SaveChangesAllAsync();
    }
}
