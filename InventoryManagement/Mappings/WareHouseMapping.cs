using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class WareHouseMapping:Profile
{
    public WareHouseMapping()
    {
        CreateMap<CreateWareHouseDTO, WareHouse>().ReverseMap();
        CreateMap<UpdateWareHouseDTO, WareHouse>().ReverseMap() ;
        CreateMap<WareHouse,ResponseWareHouseDTO>();
    }
}
