using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class SupplierMapping:Profile
{
    public SupplierMapping()
    {
        CreateMap<CreateSupplierDTO,Supplier>().ReverseMap();
        CreateMap<UpdateSupplierDTO, Supplier>().ReverseMap();
        CreateMap<Supplier,ResponseSupplierDTO>();
    }
}