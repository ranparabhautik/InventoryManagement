using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Model;

namespace InventoryManagement.Mappings;

public class PurchaseOrderMapping:Profile
{
    public PurchaseOrderMapping()
    {
        CreateMap<CreatePurchaseOrderDTO,PurchaseOrder>().ReverseMap();
        CreateMap<ItemDTO,PurchaseOrderItem>().ReverseMap();

        CreateMap<PurchaseOrder,ResponseOrderPurchaseDTO>().ForMember(dest=> dest.SupplierName,opt=> opt.MapFrom(src=> src.Supplier.SupplierName)).ForMember(dest=> dest.WareHouseName, opt=> opt.MapFrom(src=> src.Warehouse.WareHouseName)).ForMember(dest=> dest.Items,opt=> opt.MapFrom(src=> src.PurchaseOrderItems));      



    }
}
