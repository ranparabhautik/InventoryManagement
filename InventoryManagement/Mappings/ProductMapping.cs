using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductDTO,Product>().ReverseMap();
        CreateMap<UpdateProductDTO, Product>().ReverseMap();

        CreateMap<Product,ResponseProductDTO>().ForMember(dest => dest.CategoryName,opt=> opt.MapFrom(src=> src.ProductCategories.CategoryName)).ForMember(dest=> dest.SupplierName,opt=> opt.MapFrom(src=> src.Supplier.SupplierName));
    }
}
