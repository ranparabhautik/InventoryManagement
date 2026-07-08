using InventoryManagement.DTOs;

namespace InventoryManagement.Services.Interface;

public interface IWareHouseService
{
    Task<IEnumerable<ResponseWareHouseDTO>> GetAllWareHouse();
    Task<ResponseWareHouseDTO?> GetWareHouseById(Guid Id);
    Task CreateWareHouse(CreateWareHouseDTO dto);
    Task UpdateWareHouse(Guid Id, UpdateWareHouseDTO dto);
    Task DeleteWareHouse(Guid Id);
}
