using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class InventoryProfile:Profile
{
    public InventoryProfile()
    {
        CreateMap<Inventory,ResponseInventoryDTO>().ForMember(dest=> dest.ProductName,opt=> opt.MapFrom(src=> src.Product.ProductName)).ForMember(dest=> dest.WarehouseName,opt=> opt.MapFrom(src=> src.WareHouse.WareHouseName));
    }
}
