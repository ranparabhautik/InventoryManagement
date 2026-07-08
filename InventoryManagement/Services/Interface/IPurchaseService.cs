using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Interface;

public interface IPurchaseService
{
    Task CreatePurchaseOrder(CreatePurchaseOrderDTO dto);
    Task RecievePurchaseOrder(Guid PurchaseOrderId);
    Task<IEnumerable<ResponseOrderPurchaseDTO>> GetAllOrders();
    Task<ResponseOrderPurchaseDTO> GetPurchaseOrderById(Guid Id);
}
