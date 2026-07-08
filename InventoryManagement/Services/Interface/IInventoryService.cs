using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Interface;

public interface IInventoryService
{
    Task StockIn(StockDTO dto);
    Task StockOut (StockDTO dto);
    Task<IEnumerable<ResponseInventoryDTO>> GetAllInventory();
    Task TransferStock(TransferStockDTO dto);
    Task<ResponseInventoryDTO> GetInventory(Guid ProductId,Guid WarehouseId );
}
