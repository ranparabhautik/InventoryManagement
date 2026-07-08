using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class CategoryMapping:Profile
{
    public CategoryMapping()
    {
        CreateMap<CreateCategoryDTO, ProductCategories>().ReverseMap();
        CreateMap<UpdateCategoriesDTO, ProductCategories>().ReverseMap();
        CreateMap<ProductCategories,ResponseCategoryDTO>();
    }
}
