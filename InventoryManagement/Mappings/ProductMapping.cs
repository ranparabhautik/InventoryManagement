using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductDTO,Product>().ReverseMap().ForMember(d=> d.CategoryId,opt=> opt.MapFrom(s=> s.ProductCategories.Id)).ForMember(d=> d.SupplierId,opt=> opt.MapFrom(s=> s.Supplier.Id));
        CreateMap<UpdateProductDTO, Product>().ReverseMap().ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.ProductCategories.Id)).ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.Supplier.Id));

        CreateMap<Product,ResponseProductDTO>().ForMember(dest => dest.CategoryName,opt=> opt.MapFrom(src=> src.ProductCategories.CategoryName)).ForMember(dest=> dest.SupplierName,opt=> opt.MapFrom(src=> src.Supplier.SupplierName)).ForMember(dest=> dest.ProductId,opt=> opt.MapFrom(src=> src.Id));
    }
}
