using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Interface;

public interface ICategoryService
{
    Task<IEnumerable<ResponseCategoryDTO>> GetAllCategory();
    Task<ResponseCategoryDTO?> GetCategoryById(Guid Id);
    Task CreateCategory(CreateCategoryDTO dto);
    Task UpdateCategory(Guid Id,UpdateCategoriesDTO dto);
    Task DeleteCategory(Guid Id);
}
